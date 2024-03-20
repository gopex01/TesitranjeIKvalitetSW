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

        //[SetUp]
        [OneTimeSetUp]
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
            
            var adminService = new AdminService(appContext);
            var newAdmin = new AdminEntity
            {
                Username = username,
                Password = password
            };

         
            var result = adminService.createAdmin(newAdmin);

          
            Assert.AreEqual("Admin uspesno dodat", result);
        }



        [Test]
        [TestCase("Zeljko Vasic","password123")]
        public void CreateAdmin_DuplicateUsername_ReturnsErrorMessage(string username,string password)
        {
            
            var adminService = new AdminService(appContext);
            var newAdmin = new AdminEntity
            {
                Username = username, // Koristimo postojeće korisničko ime
                Password = password
            };

           
            var result = adminService.createAdmin(newAdmin);

            
            Assert.AreEqual("Admin vec postoji", result);
        }


        
        [Test]
        [TestCase("","asd")]
        public void CreateAdmin_EmptyUsernameOrPassword_ReturnsErrorMessage(string username, string password)
        {
           
            var adminService = new AdminService(appContext);
            var newAdmin = new AdminEntity
            {
                Username = username, // prazan username 
                Password = password 
            };

            
            var result = adminService.createAdmin(newAdmin);

            
            Assert.AreEqual("Korisnicko ime ili lozinka nisu uneseni", result);
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
        public void getAdminWrongUsername(string username)
        {
            var result = adminService.getAdmin(username);
            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase(1)]
        public void deleteAdminSuccess(int id)
        {
            var result = adminService.deleteAdmin(id);
            Assert.AreEqual("Success", result);

        }

        [Test]
        [TestCase(10)]
        public void deleteAdminNotFound(int id)
        {
            var result = adminService.deleteAdmin(id);
            Assert.AreEqual("Not found", result);

        }

        [Test]
        [TestCase(-1)]
        public void deleteAdminNegativeID(int id)
        {
            var result = adminService.deleteAdmin(id);
            Assert.AreEqual("Negativan ID", result);

        }


        [Test]
        [TestCase(1,"newUsername")]
        public void updateAdminsUsernameSuccess(int IdAdmin, string newUsername)
        {
            var result = adminService.updateAdminUsername(IdAdmin, newUsername);
            Assert.AreEqual("Success", result);

        }

        [Test]
        [TestCase(10, "newUsername")]
        public void updateAdminsUsernameNonExistingID(int IdAdmin, string newUsername)
        {
            var result = adminService.updateAdminUsername(IdAdmin, newUsername);
            Assert.AreEqual("Not found", result);

        }

        [Test]
        [TestCase(-10, "newUsername")]
        public void updateAdminsUsernameNegativeID(int IdAdmin, string newUsername)
        {
            var result = adminService.updateAdminUsername(IdAdmin, newUsername);
            Assert.AreEqual("Negativan ID", result);

        }



       


        [Test]
        [TestCase(1, "newPassword")]
        public void updateAdminsPasswordSuccess(int IdAdmin, string newPassword)
        {
            var result = adminService.updatePassword(IdAdmin, newPassword);
            Assert.AreEqual("Success", result);

        }

        [Test]
        [TestCase(10, "newPassword")]
        public void updateAdminsPasswordNonExistingID(int IdAdmin, string newPassword)
        {
            var result = adminService.updatePassword(IdAdmin, newPassword);
            Assert.AreEqual("Not found", result);

        }

        [Test]
        [TestCase(-10, "newPassword")]
        public void updateAdminsPasswordNegativeID(int IdAdmin, string newPass)
        {
            var result = adminService.updateAdminUsername(IdAdmin, newPass);
            Assert.AreEqual("Negativan ID", result);

        }





    }
}
