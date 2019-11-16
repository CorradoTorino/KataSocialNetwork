using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApiTests
{
    public class UserControllerTests
    {
        protected UsersController controller;
        private SocialNetworkContext context;

        protected static User ExtractUserFromCreatedAtActionResult(ActionResult<User> actionResult)
        {
            var createdAtActionResult = actionResult.Result as CreatedAtActionResult;

            Assert.IsNotNull(createdAtActionResult, "the action result was not a 'CreatedAtActionResult'.");
            var userCreated = createdAtActionResult.Value as User;
            Assert.IsNotNull(userCreated, "The Value was not a 'User'");
            return userCreated;
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