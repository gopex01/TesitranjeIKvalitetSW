using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest
{
    [TestFixture]
    public class TermTest
    {
        private AppDbContext appContext;
        private TerminService terminService;
        private BorderCrossService borderCrossService;
        private UserService userService;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "TestDatabase")
               .Options;


            appContext = new AppDbContext(options);
            var bcs = new List<BorderCrossEntity>
            {
                new BorderCrossEntity{Id=4,Name="Gradina",Username="GradinaGP",Password="Gradina",Location="East",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Gradina@gmail.com",PhoneNumber="010292929",Description="nodesc"},
                new BorderCrossEntity{Id=5,Name="Horgos",Username="HorgosGP",Password="Horgos",Location="North",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Horgos@gmail.com",PhoneNumber="010392929",Description="nodesc"},
                new BorderCrossEntity{Id=6,Name="Batrovci",Username="BatrovciGP",Password="Batrovci",Location="North",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Batrovci@gmail.com",PhoneNumber="010592929",Description="nodesc"}
            };
            var users = new List<UserEntity>
            {
                 new UserEntity{ Id = 4,NameAndSurname="Zeljko Vasic",Email="zeljko@gmail.com",Username="zeks",Password="zeljko",PhoneNumber="064192992",Age=19,JMBG="029102910901"},
                new UserEntity{Id=5,NameAndSurname="Mihajlo Madic",Email="mihajlo@gmail.com",Username="mixa",Password="mixa",PhoneNumber="065991919",Age=22,JMBG="029292101951"},
                new UserEntity{Id=6,NameAndSurname="Vladan Vasic",Email="vladan@gmail.com",Username="vaske",Password="vaske",PhoneNumber="064919191",Age=25,JMBG="29201010191"}
            };
            var initialData = new List<TermEntity>
            {

                new TermEntity{ Id = 1,NumOfPassengers=2,CarBrand="Audi",NumOfRegistrationPlates="PI029PP",ChassisNumber="2skoskao92ka",NumberOfDays=4,PlaceOfResidence="Grcka",DateAndTime=new DateTime(),IsPaid=false,IsCrossed=false,IsComeBack=false,Irregularities="nema",user=users[0],borderCross=bcs[0] },//,user=new UserEntity{Id = 2,NameAndSurname="Zeljko Vasic",Email="zeljko@gmail.com",Username="zeks",Password="zeljko",PhoneNumber="064192992",Age=19,JMBG="029102910901"},borderCross=new BorderCrossEntity{Id=1,Name="Gradina",Username="GradinaGP",Password="Gradina",Location="East",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Gradina@gmail.com",PhoneNumber="010292929",Description="nodesc" } },
                 new TermEntity{ Id = 2,NumOfPassengers=4,CarBrand="VW",NumOfRegistrationPlates="NI029PP",ChassisNumber="OS9Ak92ka",NumberOfDays=5,PlaceOfResidence="Turska",DateAndTime=new DateTime(),IsPaid=false,IsCrossed=false,IsComeBack=false,Irregularities="nema",user=users[1],borderCross=bcs[1] },//=new UserEntity{Id = 3,NameAndSurname="Zeljko Madic",Email="zeljko@gmail.com",Username="zeks",Password="zeljko",PhoneNumber="064192992",Age=19,JMBG="029102910901"},borderCross=new BorderCrossEntity{Id=2,Name="Horgos",Username="HorgosGP",Password="Gradina",Location="East",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Gradina@gmail.com",PhoneNumber="010292929",Description="nodesc" } },
                  new TermEntity{ Id = 3,NumOfPassengers=5,CarBrand="BMW",NumOfRegistrationPlates="BG029PP",ChassisNumber="2sppsij1o92ka",NumberOfDays=7,PlaceOfResidence="Bugarska",DateAndTime=new DateTime(),IsPaid=false,IsCrossed=false,IsComeBack=false,Irregularities="nema",user=users[2],borderCross=bcs[2] },//=new UserEntity {Id = 4,NameAndSurname="Zeljko Petric",Email="zeljko@gmail.com",Username="zeks",Password="zeljko",PhoneNumber="064192992",Age=19,JMBG="029102910901" },borderCross=new BorderCrossEntity{Id=3,Name="Batrovci",Username="BatrovciGP",Password="Gradina",Location="East",Country="Serbia",Type="transport",WorkHour="00-24H",TransportConnections="transport",Capacity="12",Email="Gradina@gmail.com",PhoneNumber="010292929",Description="nodesc"} },

            };
          


            appContext.CrossBorders.AddRange(bcs);
            appContext.SaveChanges();
            appContext.Users.AddRange(users);
            appContext.SaveChanges();
            appContext.Terms.AddRange(initialData);
            appContext.SaveChanges();
            userService = new UserService(appContext);
            borderCrossService = new BorderCrossService(appContext);
            terminService=new TerminService(appContext,borderCrossService,userService);
        }


        [Test]
        [TestCase(1, "bmw", "024EL", "123dasd", 5, "asd", false, true, true, "nema", true)]
        public async Task addTerminSuccess(int numOfPassenger, string CarBrand, string NumOfRegistrationPlates, string ChassisNumber, int NumberOfDays, string placeOfResidence,
     bool isPaid, bool isCrossed, bool isComeBack, string irregularities, bool Accepted)
        {
            DateTime dateAndTime = DateTime.MinValue; // Možete koristiti DateTime.MinValue, DateTime.MaxValue ili bilo koju drugu konstantu koja odgovara vašim potrebama u testiranju.

            // Testiranje logike metode addTerminSuccess
            var newTerm = new TermEntity
            {
                 NumOfPassengers = numOfPassenger,
                 CarBrand= CarBrand,
                 NumOfRegistrationPlates= NumOfRegistrationPlates,
                 ChassisNumber = ChassisNumber,
                 NumberOfDays= NumberOfDays,
                 DateAndTime=dateAndTime,
                 PlaceOfResidence = placeOfResidence,
                 IsPaid= isPaid,
                 IsCrossed=isCrossed,
                 IsComeBack=isComeBack,
                 Irregularities=irregularities
         

            };

            var rez =  await terminService.createTermin(newTerm,"zeks", "Gradina");
            Assert.That(rez,Is.Not.Null);
            Assert.AreEqual(rez, "Success");


        }

        [Test]
        [TestCase(1, "bmw", "024EL", "123dasd", 5, "asd", false, true, true, "nema", true)]
        public async Task AddTerminBadUsername(int numOfPassenger, string CarBrand, string NumOfRegistrationPlates, string ChassisNumber, int NumberOfDays, string placeOfResidence,
        bool isPaid, bool isCrossed, bool isComeBack, string irregularities, bool Accepted)
        {
            DateTime dateAndTime = DateTime.MinValue; // Možete koristiti DateTime.MinValue, DateTime.MaxValue ili bilo koju drugu konstantu koja odgovara vašim potrebama u testiranju.

            // Testiranje logike metode addTerminSuccess
            var newTerm = new TermEntity
            {
                NumOfPassengers = numOfPassenger,
                CarBrand = CarBrand,
                NumOfRegistrationPlates = NumOfRegistrationPlates,
                ChassisNumber = ChassisNumber,
                NumberOfDays = NumberOfDays,
                DateAndTime = dateAndTime,
                PlaceOfResidence = placeOfResidence,
                IsPaid = isPaid,
                IsCrossed = isCrossed,
                IsComeBack = isComeBack,
                Irregularities = irregularities


            };

            var rez = await terminService.createTermin(newTerm, "NevalidUsername", "Gradina");
            Assert.That(rez, Is.Not.Null);
            Assert.AreEqual(rez, "Error");


        }

        [Test]
        [TestCase(1, "bmw", "024EL", "123dasd", 5, "asd", false, true, true, "nema", true)]
        public async Task AddTerminBadBorderCross(int numOfPassenger, string CarBrand, string NumOfRegistrationPlates, string ChassisNumber, int NumberOfDays, string placeOfResidence,
      bool isPaid, bool isCrossed, bool isComeBack, string irregularities, bool Accepted)
        {
            DateTime dateAndTime = DateTime.MinValue; // Možete koristiti DateTime.MinValue, DateTime.MaxValue ili bilo koju drugu konstantu koja odgovara vašim potrebama u testiranju.

            // Testiranje logike metode addTerminSuccess
            var newTerm = new TermEntity
            {
                NumOfPassengers = numOfPassenger,
                CarBrand = CarBrand,
                NumOfRegistrationPlates = NumOfRegistrationPlates,
                ChassisNumber = ChassisNumber,
                NumberOfDays = NumberOfDays,
                DateAndTime = dateAndTime,
                PlaceOfResidence = placeOfResidence,
                IsPaid = isPaid,
                IsCrossed = isCrossed,
                IsComeBack = isComeBack,
                Irregularities = irregularities

            };

            var rez = await terminService.createTermin(newTerm, "zeks", "NevalidBorderCross");
            Assert.That(rez, Is.Not.Null);
            Assert.AreEqual(rez, "Error");


        }



        //[Test]
        //[TestCase()]
        //public void addTerminThrowException()
        //{

        //}

        [Test]
        [Order(3)]
        [TestCase("GradinaGP")]
        public async Task getTermsAsyncSuccess(string username)
        {
            var result =   terminService.GetTermsAsync(username);
            Assert.AreEqual(1,result.Length);
        }
        [Test]
        [TestCase("PresevoGP")]
        public async Task getTermsAsyncNull(string username)
        {
            var result =  terminService.GetTermsAsync(username);
            Assert.That(result, Is.Empty);
        }


        [Test]
        [TestCase("brojslovaveciod15asdasdegww")]
        public async Task GetTaskAsyncMoreThan15letters(string username)
        {
            var result= terminService.GetTermsAsync(username);
            Assert.That(result, Is.Null);

        }

       
        [Test]
        public void getNumOfTermsSuccess()
        {
            var result=terminService.getNumOfTerms();
            Assert.AreEqual(result, 3); 
        }
        [Test]
        public void getNumOfTermsWhenDatabaseIsEmpty()
        {


            appContext.Terms.RemoveRange(appContext.Terms);
            appContext.SaveChanges();

            var result = terminService.getNumOfTerms();
            Assert.AreEqual( result,0);

        }


        [Test]
        [Order(2)]
        [TestCase(2, true, false, "sve ok")]
        public void updateTerm(int idTerm, Boolean isCrosses, Boolean isComeBack, string irreg)
        {

            var result = terminService.updateTerm(idTerm, isCrosses, isComeBack, irreg);

            Assert.AreEqual("Success", result);


        }
        [Test]
        [Order(3)]
        [TestCase(58,true,true,"no")]
        public void updateTermError(int idTerm,Boolean isCrossed,Boolean isComeBack,string irregularities)
        {
            var result=terminService.updateTerm(idTerm,isCrossed,isComeBack,irregularities);
            Assert.AreEqual("error", result);
        }
        [Test]
        [Order(4)]
        [TestCase(-10,true,true,"no")]
        public void updateTermBadID(int idTerm,Boolean isCrossed,Boolean isComeBack,string iireg)
        {
            var result= terminService.updateTerm(idTerm,isCrossed,isComeBack,iireg);
            Assert.AreEqual("Negativan ID", result);
        }

        [Test]
        [TestCase("zeks")]
        public  async Task getPersonalTermsSuccess(string username)
        {
            var result =  terminService.GetPersonalTermsAsync(username);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [TestCase("zeks1")]
        public async Task getPersonalTermsFail(string username)
        {

            var result =  terminService.GetPersonalTermsAsync(username);
            Assert.That(result, Is.Empty);

        }

        [Test]
        [TestCase("usernameduziod15karaktera")]
        public async Task getPersonalTermsMorethan15(string username)
        {
            var result = terminService.GetPersonalTermsAsync(username);
            Assert.That(result, Is.Null);
        }
        [Test]
        [Order(15)]
        [TestCase(3)]
        public void deleteTermSuccess(int id)
        {
            var result=terminService.deleteTerm(id);
            Assert.AreEqual(result, "Success");
        }
        [Test]
        [Order(16)]
        [TestCase(54)]
        public void deleteTermError(int id)
        {
            var result = terminService.deleteTerm(id);
            Assert.AreEqual(result, "error");
        }
        [Test]
        [Order(17)]
        [TestCase(-10)]
        public void deleteTermBadID(int id)
        {
            var result = terminService.deleteTerm(id);
            Assert.AreEqual(result, "Negativan ID");
            //napisal sam odo da serem
            //
        }






  }

}
