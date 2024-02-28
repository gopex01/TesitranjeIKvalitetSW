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
        [TestCase("john","password123")]
        public void CreateAdmin_SuccessfullyAddsAdmin_ReturnsSuccessMessage(string username,string password)
        {
            // Arrange
            var adminService = new AdminService(appContext);
            var newAdmin = new AdminEntity
            {
                Username = username,
                Password = password
            };

            // Act
            var result = adminService.createAdmin(newAdmin);

            // Assert
            Assert.AreEqual("Admin uspesno dodat", result);
        }



        [Test]
        [TestCase("Zeljko Vasic","password123")]
        public void CreateAdmin_DuplicateUsername_ReturnsErrorMessage(string username,string password)
        {
            // Arrange
            var adminService = new AdminService(appContext);
            var newAdmin = new AdminEntity
            {
                Username = username, // Koristimo postojeće korisničko ime
                Password = password
            };

            // Act
            var result = adminService.createAdmin(newAdmin);

            // Assert
            Assert.AreEqual("Admin vec postoji", result);
        }


        [Test]
        public void CreateAdmin_ExceptionThrown_ReturnsErrorMessage()
        {
                //ovo naknadno
        }

        [Test]
        [TestCase("Zeljko Vasic")]
        public void getAdminSuccess(string username)
        {
            var result= adminService.getAdmin(username);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<AdminEntity>());
            Assert.That(result.Username, Is.EqualTo(username));
        }

        [Test]
        [TestCase("nonusername")]
        public void getAdminNull(string username)
        {
            var result = adminService.getAdmin(username);
            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("nonusername")]
        public void getUserExceptionThrowReturnNull(string username)
        {
            //da se doda
        }




    }
}
