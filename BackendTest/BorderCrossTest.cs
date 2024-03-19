using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest
{
   
    [TestFixture]
    public class BorderCrossTest
    {
        private AppDbContext appContext;
        private BorderCrossService bcService;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "TestDatabase")
               .Options;


            appContext = new AppDbContext(options);
            var initialData = new List<BorderCrossEntity>
            {
               
                new BorderCrossEntity{Name="Gradina",Username="GradinaGP",Password="Gradina",Location="East",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Gradina@gmail.com",PhoneNumber="010292929",Description="nodesc"},
                new BorderCrossEntity{Name="Horgos",Username="HorgosGP",Password="Horgos",Location="North",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Horgos@gmail.com",PhoneNumber="010392929",Description="nodesc"},
                new BorderCrossEntity{Name="Batrovci",Username="BatrovciGP",Password="Batrovci",Location="North",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Batrovci@gmail.com",PhoneNumber="010592929",Description="nodesc"}

            };

            appContext.CrossBorders.AddRange(initialData);
            appContext.SaveChanges();
            bcService=new BorderCrossService(appContext);
        }
        
        [Test]
        [Order(6)]
        [TestCase("Batocina","BatocinaGP","Batocina","West","Serbia","Transport","00-24h","transport","10","Batocina@gmail.com","01082929","nodesc")]
        public void createBCSuccess(string name,string username,string password,string location,string country,string type,string workhour,string transconn,string capacity,string email,string phonenumber,string desc)
        {
            var newBC = new BorderCrossEntity
            {
                Name = name,
                Username = username,
                Password = password,
                Location = location,
                Country = country,
                Type = type,
                WorkHour = workhour,
                TransportConnections = transconn,
                Capacity = capacity,
                Email = email,
                PhoneNumber = phonenumber,
                Description = desc
            };
            var bc = bcService.createBorderCross(newBC);
            //Assert.That(bc, Is.Not.Null);
            //Assert.That(bc, Is.EqualTo("new Border Cross added!"));
            Assert.AreEqual("new Border Cross added!",bc );


        }
        
        [Test]
        [Order(7)]
        [TestCase("Presevo", "PresevoGPksadsakjdaksjdkajdksa", "Presevo", "West", "Serbia", "Transport", "00-24h", "transport", "10", "Batocina@gmail.com", "01082929", "nodesc")]
        public void createBCFailureMissingParrameter(string name, string username, string password, string location, string country, string type, string workhour, string transconn, string capacity, string email, string phonenumber, string desc)
        {
            var newBC = new BorderCrossEntity
            {
                Name=name,
                Username = username,
                Password = password,
                Location = location,
                Country = country,
                Type = type,
                WorkHour = workhour,
                TransportConnections = transconn,
                Capacity = capacity,
                Email = email,
                PhoneNumber = phonenumber,
                Description = desc
            };
            var bc = bcService.createBorderCross(newBC);
            Assert.That(bc, Is.Not.Null);
            Assert.That(bc, Is.EqualTo("Not valid username"));
            
        }
       
        [Test]
        [Order(8)]
        [TestCase("Kalotina", "KalotinaGP", "Kalotina", "West", "Serbia", "Transport", "00-24h", "transport", "10", "Batocina@gmail.com", "010829291231456", "nodesc")]
        public void createBCNotValidPhoneNumber(string name, string username, string password, string location, string country, string type, string workhour, string transconn, string capacity, string email, string phonenumber, string desc)
        {
            var newBC = new BorderCrossEntity
            {
                Name=name,
                Username = username,
                Password = password,
                Location = location,
                Country = country,
                Type = type,
                WorkHour = workhour,
                TransportConnections = transconn,
                Capacity = capacity,
                Email = email,
                PhoneNumber = phonenumber,
                Description = desc
            };
            var bc = bcService.createBorderCross(newBC);
            Assert.That(bc, Is.Not.Null);
            Assert.That(bc, Is.EqualTo("Not valid phoneNumber"));

        }




        
        [Test]
        [Order(1)]
        public void getAllBCSSuccess()
        {
            var result = bcService.getALLBCS();
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0].Username, "GradinaGP");
            Assert.AreEqual(result[1].Username, "HorgosGP");
            Assert.AreEqual(result[2].Username, "BatrovciGP");

        }
        [Test]
        [Order(17)]
        public void getAllBCSWhenBaseIsEmpty()
        {
            appContext.CrossBorders.RemoveRange(appContext.CrossBorders);
            appContext.SaveChanges();

            var result= bcService.getALLBCS();
            Assert.AreEqual(0, result.Length);
        }

        
        [Test]
        [Order(2)]
        [TestCase("GradinaGP","Gradina")]
        public void getOneBCSucess(string username,string name)
        {
            var result=bcService.getOneBC(username);

            Assert.That(result,Is.Not.Null);
            Assert.AreEqual(result.Username, username);
            Assert.AreEqual(result.Name, name);
        }
     
        [Test]
        [Order(9)]
        [TestCase("exampleUsername")]
        public void getOneBCNull(string username)
        {
            var result = bcService.getOneBC(username);
            Assert.That(result,Is.Null); 
        }
        
        [Test]
        [Order(10)]
        [TestCase("GradinaGP")]
        public void getOneBCThrowException(string username)
        {
            //ovo dodajemo kasnije
        }
      
        [Test]
        [Order(4)]
        [TestCase("Gradina","GradinaGP")]
        public void getBCByNameSuccess(string name,string username)
        {
            var result = bcService.getBCByName(name);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Name, name);
            Assert.AreEqual(result.Username, username);
        }
      
        [Test]
        [Order(11)]
        [TestCase("ExampleName")]
        public void getBCByNameNull(string name)
        { 
            var result=bcService.getBCByName(name);
            Assert.That(result, Is.Null);

        }
        
        [Test]
        [Order(12)]     
        [TestCase("GradinaGradinaGradinaGradina123")]
        public void getBCByNameTooLongName(string name)
        {
            var result = bcService.getBCByName(name);
            Assert.That(result, Is.Null);

        }
     
        [Test]
        [Order(5)]
        public void getNumOfBCSSuccess()
        {
            var result = bcService.getNumOfBC();
            Assert.AreEqual(3,result);
        }

        [Test]
        public void getNumOfBCSWhenBaseIsEmpty()
        {
            appContext.CrossBorders.RemoveRange(appContext.CrossBorders);
            appContext.SaveChanges();

            var result = bcService.getNumOfBC();
            Assert.AreEqual(0,result);
        }
    
        
     
        [Test]
        [Order(13)]
        [TestCase("Gradina")]
        public void deleteBCSuccess(string name)
        {
            var result = bcService.deleteBC(name);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result,"Success");
            //Assert.AreEqual(appContext.CrossBorders.Count(), 2);
        }
       
        [Test]
        [Order(14)]
        [TestCase("Examplename")]
        public void deleteNullBC(string name)
        {
            var result=bcService.deleteBC(name);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result, "Error");
            //Assert.AreEqual(3,appContext.CrossBorders.Count());
        }
        
        [Test]
        [Order(15)]
        [TestCase("GradinaGradinaGradinaGradina123")]
        public void deleteBCThrowException(string name)
        {
            var result = bcService.deleteBC(name);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result, "Too long name");
        }
    }
}
