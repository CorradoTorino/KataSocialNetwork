using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Models;

namespace WebApiTests
{
    [TestClass]
    public class UsersControllerDeleteUserTests: UserControllerTests
    {
        [TestMethod]
        public async Task DeleteUser_DeleteTheExistingUser()
        {
            // Arrange
            var userCreated = ExtractUserFromCreatedAtActionResult(
                await controller.PostUser(new User() { Name = "dummyName" }));
            
            // Act
            var result = await controller.DeleteUser(userCreated.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userCreated, result.Value,
                "The deleted user does not correspond with the created one.");
        }

        [TestMethod]
        public async Task DeleteUser_ReturnNotFoundResult()
        {
            // Act
            var result = await controller.DeleteUser(1234);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "Unexpected result returned.");
        }

        [TestMethod]
        public async Task DeleteUser_ReturnNotFoundStatusCode()
        {
            // Act
            var result = await controller.DeleteUser(1234);

            // Assert
            var notFoundResult = result.Result as NotFoundResult;
            Assert.IsNotNull(notFoundResult, "Unexpected result returned.");
            Assert.AreEqual((int)HttpStatusCode.NotFound, notFoundResult.StatusCode,
                "Unexpected http code returned");
        }
    }
}
