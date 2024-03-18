using NUnit.Framework;
using Moq;
using projekat1.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BackendTest
{
    [TestFixture]
    public class UserTests
    {

        private AppDbContext appContext;
        private UserService userService;

        [OneTimeSetUp]
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
        [Order(1)]
        [TestCase("John Doe", "john@example.com","john", "password", "123456789", 25, "12309521101")]
        public void CreateUserSuccessMessage(string NameAndSurname, string email, string username,string password, string phonenumber, int age, string jmbg)
        {
            // Arrange
            var newUser = new UserEntity
            {
                NameAndSurname = NameAndSurname,
                Email = email,
                Username = username,
                Password = password,
                PhoneNumber = phonenumber,
                Age = 25,
                JMBG = jmbg
            };

            // Act
            var result = userService.createUser(newUser);

            // Assert
            Assert.That(result, Is.Not.Null);

            Assert.AreEqual("Korisnik uspesno dodat", result);
 
        }
        [Test]
        [Order(2)]
        [TestCase("John Dap", "johndap@example.com", "johndap", "passworddap", "1415156789", 20, "123067534321101")]
        public void createUserErrorMessage(string NameAndSurname, string email, string username, string password, string phonenumber, int age, string jmbg)
        {
            var newUser = new UserEntity
            {
                NameAndSurname = NameAndSurname,
               
                Username = username,
                Password = password,
                PhoneNumber = phonenumber,
                Age = 25,
                JMBG = jmbg
            };
            var result = userService.createUser(newUser);
            Assert.AreEqual("Greška prilikom dodavanja korisnika", result);
            TearDown(); 
        }

        [Test]
        [Order(3)]
        [TestCase("Petar Doe", "petar@example.com", "petar", "petar", "123845119", -25, "123666611201")]
        public void createUserWithBadAgeValue(string NameAndSurname, string email, string username, string password, string phonenumber, int age, string jmbg)
        {
            var newUser = new UserEntity
            {
                NameAndSurname = NameAndSurname,
                Email=email,
                Username = username,
                Password = password,
                PhoneNumber = phonenumber,
                Age = age,
                JMBG = jmbg
            };
            var result = userService.createUser(newUser);
            Assert.AreEqual("Error", result);
            TearDown();
        }
        [Test]
        [Order(4)]
        [TestCase("zeks")]
        public void getUserReturnSuccess(string username)
        {
            var result=userService.getUser(username);
            Assert.That(result,Is.Not.Null);
            Assert.That(result, Is.TypeOf<UserEntity>());
            Assert.That(result.Username,Is.EqualTo(username));  
        }
        [Test]
        [Order(5)]
        [TestCase("petar")]
        public void getNullUser(string username)
        {
            var result=userService.getUser(username);
            Assert.That(result, Is.Null);
        }
        
        [Test]
        [Order(6)]
        [TestCase("useruseruseruseruseruseruse")]
        public void getUserUsernamelengthmorethan15(string username)
        {
            var result = userService.getUser(username);
            Assert.IsNull(result);
        }

        [Test]
        [Order(7)]
        public void getAllUsersReturnArray()
        {
            var result = userService.getAllUsers();

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual("Zeljko Vasic", result[0].NameAndSurname);
            Assert.AreEqual("Mihajlo Madic", result[1].NameAndSurname);
            Assert.AreEqual("Vladan Vasic", result[2].NameAndSurname);
        }
        [Test]
        [Order(24)]
        public void getUsersWhenDatabaseIsEmpty()
        {
            //prvo se uklone useri iz baze

            appContext.Users.RemoveRange(appContext.Users);
            appContext.SaveChanges();

            var result = userService.getAllUsers();
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Length, 0);
            TearDown();
        }


        [Test]
        [Order(8)]
        public void getNumOfUsers()
        {
            // Act
            var result = userService.getNumOfUsers();
            Assert.AreEqual(4, result);

        }


        [Test]
        [Order(23)]
        public void getNumOfUsersWhenDatabaseIsEmpty()
        {
            //prvo se uklone useri iz baze

            appContext.Users.RemoveRange(appContext.Users);
            appContext.SaveChanges();

            var result = userService.getNumOfUsers();
           
            Assert.AreEqual(result, 0);
            TearDown();
        }





        [Test]
        [Order(9)]
        [TestCase("newPassword", "zeks")]
        public void UpdatePasswordToExistingUser(string newPassword, string username)
        {
            

            // Act
            var result = userService.updatePassword(newPassword, username);

            var user = userService.getUser(username);

            // Assert
            Assert.That(result, Is.Not.Null);

            Assert.AreEqual("Success", result);

            Assert.AreEqual(user.Password, newPassword);
            TearDown();
        }




        [Test]
        [Order(10)]
        [TestCase("newPassword", "nonExisstringPassword")]
        public void UpdatePasswordNonExistingUser(string newPassword, string username)
        {
            

            // Act
            var result = userService.updatePassword(newPassword, username);

            // Assert
            Assert.AreEqual("Error", result);
            TearDown();


        }


        [Test]
        [Order(11)]
        [TestCase("newPasswordasidjsaijdi","zeks")]
        public void updatePasswordLengthNewPassError(string newPassword,string username)
        {
            var result=userService.updatePassword(newPassword,username);
            Assert.AreEqual(result, "error");
            TearDown();


        }



        [Test]
        [Order(20)]
        [TestCase("zeljko", "zeks")]
        
        public void DeactivateAccountValid(string password,string username)
        {
            
            
            // Act
            var result = userService.deactivateAccount(username, password);

            // Assert
            Assert.AreEqual("Success", result); TearDown();
        }


        [Test]
        [Order(21)]
        public void DeactivateAccountInvalidPassword()
        {
            
            string username = "zeks";
            string password = "invalidPassword";

            // Act
            var result = userService.deactivateAccount(username, password);

            // Assert
            Assert.AreEqual("Error", result);
            TearDown();
        }


        [Test]
        [Order(22)]
        public void DeactivateAccount_NonexistentUser_ReturnsError()
        {
            
            string username = "nonexistentUser";
            string password = "zeljko";

            // Act
            var result = userService.deactivateAccount(username, password);

            // Assert
            Assert.AreEqual("Error", result);
            TearDown();
        }






        //UPDATEPHONENUMBER
        [Test]
        [Order(12)]
        [TestCase("065123456", "zeks")]
        public void UpdatePhoneNumberExistingUser(string newPhoneNumber, string username)
        {
            var result = userService.updatePhoneNumber(newPhoneNumber, username);
            Assert.AreEqual("Success", result);
            TearDown();
        }


        [Test]
        [Order(13)]
        [TestCase("065123456", "nonexistentUser")]
        public void UpdatePhoneNumber_NonexistentUser_ReturnsError(string newPhoneNumber, string username)
        {
            var result = userService.updatePhoneNumber(newPhoneNumber, username);
            Assert.AreEqual("Error", result);
            TearDown();
        }

        [Test]
        [Order(14)]
        [TestCase("065123456", "nonexistentUser")]
        public void UpdatePhoneNumberLengthError(string newPhoneNumber, string username)
        {
            var result = userService.updatePhoneNumber(newPhoneNumber, username);
            Assert.AreEqual(result, "Error");
            TearDown();
        }


        //updateUsername

        [Test]
        [Order(15)]
        [TestCase("newUsername", "zeks")]
        public void UpdateUsername_ExistingUser_ReturnsSuccess(string newUsername, string username)
        {
            // Act
            var result = userService.updateUsername(newUsername, username);
            // Assert
            Assert.AreEqual("Success", result);
             TearDown();
        }


        [Test]
        [Order(16)]
        [TestCase("newUsername", "nonexistentUser")]
        public void UpdateUsername_NonexistentUser_ReturnsError(string newUsername, string username)
        {
           

            // Act
            var result = userService.updateUsername(newUsername, username);

            // Assert
            Assert.AreEqual("Error", result);
            TearDown();
        }


        [Test]
        [Order(17)] 
        [TestCase("newUsernameerroeoeoeoeoeoe", "zeks")]
        public void UpdateUsernameLengthError(string newusername,string username)
        {
            var result = userService.updateUsername(newusername, username);
            Assert.AreEqual("error", result);
            TearDown();
        }



        //UPDATENAME

        [Test]
        [Order(18)]
        [TestCase("New Name", "zeks")]
        public void UpdateName_ExistingUser_ReturnsSuccess(string newName, string username)
        {
            // Arrange
            var userService = new UserService(appContext);

            // Act
            var result = userService.updateName(newName, username);

            // Assert
            Assert.AreEqual("Success", result);
            TearDown();
        }



        [Test]
        [Order(19)]
        [TestCase("New Name", "nonexistentUser")]
        public void UpdateName_NonexistentUser_ReturnsError(string newName, string username)
        {
            // Arrange
            var userService = new UserService(appContext);

            // Act
            var result = userService.updateName(newName, username);

            // Assert
            Assert.AreEqual("Error", result);
            TearDown();
        }


        [TearDown]
        public void TearDown()
        {
            // Ovdje dodajte kod za brisanje ili resetiranje baze podataka nakon završetka testa
            appContext.Database.EnsureDeleted();
        }




















    }
}