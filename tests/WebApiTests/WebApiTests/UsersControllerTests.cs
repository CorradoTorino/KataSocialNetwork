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
    public class UsersControllerTests
    {
        private UsersController controller;
        private SocialNetworkContext context;

        [TestMethod]
        public async Task PostUser_CreatedUserSuccessfully()
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

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SocialNetworkContext>()
                .UseInMemoryDatabase(databaseName: "SocialNetwork")
                .Options;
            context = new SocialNetworkContext(options);
            controller = new UsersController(context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            context.Dispose();
        }
    }
}
