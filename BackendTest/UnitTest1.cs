using NUnit.Framework;
using Moq;
using projekat1.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest
{
    [TestFixture]
    public class Tests
    {

        private AppDbContext appContext;
        private UserService userService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;


            appContext = new AppDbContext(options);
            var initialData = new List<UserEntity>
            {
                new UserEntity{ Id = 1,NameAndSurname="Zeljko Vasic",Email="zeljko@gmail.com",Username="zeks",Password="zeljko",PhoneNumber="064192992",Age=19,JMBG="029102910901"},
                new UserEntity{Id=2,NameAndSurname="Mihajlo Madic",Email="mihajlo@gmail.com",Username="mixa",Password="mixa",PhoneNumber="065991919",Age=22,JMBG="029292101951"},
                new UserEntity{Id=3,NameAndSurname="Vladan Vasic",Email="vladan@gmail.com",Username="vaske",Password="vaske",PhoneNumber="064919191",Age=25,JMBG="29201010191"}

            };

            appContext.Users.AddRange(initialData);
            appContext.SaveChanges();
            userService = new UserService(appContext);
        }

        [Test]
        [TestCase("John Doe", "john@example.com","john", "password", "123456789", 25, "12309521101")]
        public void CreateUser_WhenUserAdded_ReturnsSuccessMessage(string NameAndSurname, string email, string username,string password, string phonenumber, int age, string jmbg)
        {
            // Arrange
            var newUser = new UserEntity
            {
                NameAndSurname = NameAndSurname,
                Email = email,
                Password = password,
                PhoneNumber = phonenumber,
                Age = 25,
                JMBG = jmbg
            };

            // Act
            var result = userService.createUser(newUser);
            Console.Write(result.ToString());
            // Assert
            Assert.That(result, Is.Not.Null);

            Assert.AreEqual("Korisnik uspesno dodat", result);
            Assert.AreEqual(2, appContext.Users.Count());
        }
        [Test]
        [TestCase("zeks")]
        public void getUserReturnSuccess(string username)
        {
            var result=userService.getUser(username);
            Assert.That(result,Is.Not.Null);
            Assert.That(result, Is.TypeOf<UserEntity>());
            Assert.That(result.Username,Is.EqualTo(username));  
        }
        [Test]
        [TestCase("petar")]
        public void getNullUser(string username)
        {
            var result=userService.getUser(username);
            Assert.That(result, Is.Null);
        }
        //ovo ne radi i ne umem da ga sredim
        [Test]
        [TestCase("zeks")]
        public void getUserExceptionThrowReturnNull(string username)
        {
            var mockedDbContext = new Mock<AppDbContext>();

            mockedDbContext.SetupGet(db => db.Users).Throws(new Exception("Simulated Exception"));

            var userServiceWithMock = new UserService(mockedDbContext.Object);

            var result = userServiceWithMock.getUser(username);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void getAllUsersReturnArray()
        {
            var result = userService.getAllUsers();

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("Zeljko Vasic", result[0].NameAndSurname);
            Assert.AreEqual("Mihajlo Madic", result[1].NameAndSurname);
            Assert.AreEqual("Vladan Vasic", result[2].NameAndSurname);
        }
        [Test]
        public void getUsersWhenDatabaseIsEmpty()
        {
            //prvo se uklone useri iz baze

            appContext.Users.RemoveRange(appContext.Users);
            appContext.SaveChanges();

            var result = userService.getAllUsers();
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Length, 0);
        }
        [Test]
        public void getUsersExceptionThrowReturnNull()
        {

        }



    }
}