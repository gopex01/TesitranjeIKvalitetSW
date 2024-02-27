using NUnit.Framework;
using Moq;
using projekat1.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BackendTest
{
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
                new UserEntity{ Id = 1,NameAndSurname="Zeljko Vasic",Email="zeljko@gmail.com",Password="zeljko",PhoneNumber="064192992",Age=19,JMBG="029102910901",Verified=false}
            };

            appContext.Users.AddRange(initialData);
            appContext.SaveChanges();
            userService = new UserService(appContext);
        }

        [Test]
        public void CreateUser_WhenUserAdded_ReturnsSuccessMessage()
        {
            // Arrange
            var newUser = new UserEntity
            {
                Id = 2,
                NameAndSurname = "John Doe",
                Email = "john@example.com",
                Password = "password",
                PhoneNumber = "123456789",
                Age = 25,
                JMBG = "1234567890123",
                Verified = false
            };

            // Act
            var result = userService.createUser(newUser);
            // Assert
            Assert.AreEqual("Korisnik uspesno dodat", result);
            Assert.AreEqual(2, appContext.Users.Count()); // Provjerava je li novi korisnik dodan u bazu podataka
        }
    }
}