using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApiTests
{
    [TestClass]
    public class UsersControllerPostUserTests : UserControllerTests
    {
        [TestMethod]
        public async Task PostUser_ReturnsStatusCodeCreated()
        {
            // Act
            var result = await controller.PostUser(new User(){Name = "dummyName" });

            // Assert
            var actionResult = result.Result as CreatedAtActionResult;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual((int)HttpStatusCode.Created, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task PostUser_CreateTheExpectedUser()
        {
            // Arrange
            const string userName = "dummyName";

            // Act
            var result = await controller.PostUser(new User() { Name = userName });
            
            // Assert
            var userCreated = ((CreatedAtActionResult)result.Result).Value as User;
            Assert.IsNotNull(userCreated);
            Assert.AreEqual(userName, userCreated.Name);
        }
    }
}
