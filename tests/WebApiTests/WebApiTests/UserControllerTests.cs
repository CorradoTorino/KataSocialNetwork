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