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
               
                new BorderCrossEntity{Id=1,Name="Gradina",Username="GradinaGP",Password="Gradina",Location="East",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Gradina@gmail.com",PhoneNumber="010292929",Description="nodesc"},
                new BorderCrossEntity{Id=2,Name="Horgos",Username="HorgosGP",Password="Horgos",Location="North",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Horgos@gmail.com",PhoneNumber="010392929",Description="nodesc"},
                new BorderCrossEntity{Id=3,Name="Batrovci",Username="BatrovciGP",Password="Batrovci",Location="North",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Batrovci@gmail.com",PhoneNumber="010592929",Description="nodesc"}

            };

            appContext.CrossBorders.AddRange(initialData);
            appContext.SaveChanges();
            bcService=new BorderCrossService(appContext);
        }

        [Test]
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
            Assert.That(bc, Is.Not.Null);
            Assert.That(bc, Is.EqualTo("new Border Cross added!"));
            Assert.AreEqual(4, appContext.CrossBorders.Count());
        }

        [Test]
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
        public void getAllBCSWhenBaseIsEmpty()
        {
            appContext.CrossBorders.RemoveRange(appContext.CrossBorders);
            appContext.SaveChanges();

            var result= bcService.getALLBCS();
            Assert.AreEqual(0, result.Length);
        }

        [Test]
        public void getAllBCSThrowException()
        {
            //dodajemo kasnije
        }
        [Test]
        [TestCase("GradinaGP","Gradina")]
        public void getOneBCSucess(string username,string name)
        {
            var result=bcService.getOneBC(username);

            Assert.That(result,Is.Not.Null);
            Assert.AreEqual(result.Username, username);
            Assert.AreEqual(result.Name, name);
        }
        [Test]
        [TestCase("exampleUsername")]
        public void getOneBCNull(string username)
        {
            var result = bcService.getOneBC(username);
            Assert.That(result,Is.Null); 
        }
        [Test]
        [TestCase("GradinaGP")]
        public void getOneBCThrowException(string username)
        {
            //ovo dodajemo kasnije
        }

        [Test]
        [TestCase("Gradina","GradinaGP")]
        public void getBCByNameSuccess(string name,string username)
        {
            var result = bcService.getBCByName(name);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Name, name);
            Assert.AreEqual(result.Username, username);
        }

        [Test]
        [TestCase("ExampleName")]
        public void getBCByNameNull(string name)
        { 
            var result=bcService.getBCByName(name);
            Assert.That(result, Is.Null);

        }
        [Test]
        [TestCase("Gradina")]
        public void getBCByNameThrowException(string name)
        {
            //ovo dodajemo kasnije
        }

        [Test]
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
        public void getNumOfBCSThrowException()
        {
            //ovo dodajemo kasnije
        }
        [Test]
        [TestCase("Gradina")]
        public void deleteBCSuccess(string name)
        {
            var result = bcService.deleteBC(name);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result,"Success");
            Assert.AreEqual(appContext.CrossBorders.Count(), 2);
        }
        [Test]
        [TestCase("Examplename")]
        public void deleteNullBC(string name)
        {
            var result=bcService.deleteBC(name);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result, "Error");
            Assert.AreEqual(3,appContext.CrossBorders.Count());
        }
        [Test]
        [TestCase("Gradina")]
        public void deleteBCThrowException(string name)
        {
            //ovo dodajemo kasnije
        }
    }
}
