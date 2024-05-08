using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Index_ReturnsViewWithUserDetails()
        {
            // Arrange
            var controller = new UserController();
            var expectedUserDetails = new List<User>();

            // Act
            var result = controller.Index() as ViewResult;
            var actualUserDetails = result.Model as List<User>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUserDetails, actualUserDetails);
        }

        [TestMethod]
        public void Details_ExistingUserId_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "1234567890" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Contact = "9876543210" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Details(1) as ViewResult;
            var user = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userlist.FirstOrDefault(u => u.Id == 1), user);
        }

        [TestMethod]
        public void Details_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "1234567890" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Contact = "9876543210" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Details(3) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>();
            controller.userlist = userlist;
            var user = new User { Name = "John Doe", Email = "john.doe@example.com", Contact = "1234567890" };

            // Act
            var result = controller.Create(user) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Create_InvalidUser_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>();
            controller.userlist = userlist;
            var user = new User { Name = "John Doe", Email = "invalidemail", Contact = "1234567890" };

            // Act
            var result = controller.Create(user) as ViewResult;
            var actualUser = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, actualUser);
        }

        [TestMethod]
        public void Edit_ExistingUserId_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "1234567890" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Contact = "9876543210" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Edit(1) as ViewResult;
            var user = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userlist.FirstOrDefault(u => u.Id == 1), user);
        }

        [TestMethod]
        public void Edit_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "1234567890" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Contact = "9876543210" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Edit(3) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "1234567890" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Contact = "9876543210" }
            };
            controller.userlist = userlist;
            var user = new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "9999999999" };

            // Act
            var result = controller.Edit(1, user) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Edit_InvalidUser_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "1234567890" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Contact = "9876543210" }
            };
            controller.userlist = userlist;
            var user = new User { Id = 1, Name = "John Doe", Email = "invalidemail", Contact = "9999999999" };

            // Act
            var result = controller.Edit(1, user) as ViewResult;
            var actualUser = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, actualUser);
        }

        [TestMethod]
        public void Delete_ExistingUserId_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "1234567890" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Contact = "9876543210" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Delete(1) as ViewResult;
            var user = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userlist.FirstOrDefault(u => u.Id == 1), user);
        }

        [TestMethod]
        public void Delete_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "1234567890" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Contact = "9876543210" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Delete(3) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_Confirmed_DeletesUserAndRedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "1234567890" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Contact = "9876543210" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNull(userlist.FirstOrDefault(u => u.Id == 1));
        }
    }
}


