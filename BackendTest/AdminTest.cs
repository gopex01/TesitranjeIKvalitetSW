using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest
{

    [TestFixture]
    public  class AdminTest
    {

        private AppDbContext appContext;
        private AdminService adminService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "TestDatabase")
               .Options;


            appContext = new AppDbContext(options);
            var initialData = new List<AdminEntity>
            {
                new AdminEntity { Id = 1,Username="Zeljko Vasic",Password="zeks"},
                 new AdminEntity { Id = 2,Username="Mihajlo Madic",Password="mixa"},
                  new AdminEntity { Id = 3,Username="Vladan Vasic",Password="vladan"},


            };

            appContext.Admin.AddRange(initialData);
            appContext.SaveChanges();
            adminService = new AdminService(appContext);
        }





        [Test]
        public void CreateAdmin_SuccessfullyAddsAdmin_ReturnsSuccessMessage()
        {
            // Arrange
            var adminService = new AdminService(appContext);
            var newAdmin = new AdminEntity
            {
                Username = "john",
                Password = "password123"
            };

            // Act
            var result = adminService.createAdmin(newAdmin);

            // Assert
            Assert.AreEqual("Admin uspesno dodat", result);
        }



        [Test]
        public void CreateAdmin_DuplicateUsername_ReturnsErrorMessage()
        {
            // Arrange
            var adminService = new AdminService(appContext);
            var newAdmin = new AdminEntity
            {
                Username = "Zeljko Vasic", // Koristimo postojeće korisničko ime
              //  Password = "password123"
            };

            // Act
            var result = adminService.createAdmin(newAdmin);

            // Assert
            Assert.AreEqual("Greška prilikom dodavanja korisnika", result);
        }


        [Test]
        public void CreateAdmin_ExceptionThrown_ReturnsErrorMessage()
        {
            // Arrange
            var mockedDbContext = new Mock<AppDbContext>();
            mockedDbContext.Setup(db => db.Admin.Add(It.IsAny<AdminEntity>())).Throws(new Exception("Simulated Exception"));

            var adminServiceWithMock = new AdminService(mockedDbContext.Object);
            var newAdmin = new AdminEntity
            {
                Username = "john",
                Password = "password123"
            };

            // Act
            var result = adminServiceWithMock.createAdmin(newAdmin);

            // Assert
            Assert.AreEqual("Greška prilikom dodavanja korisnika: Simulated Exception", result);
        }




    }
}
