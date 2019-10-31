using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork;

namespace AcceptanceTests
{
    [TestClass]
    public class SocialNetworkConsoleAppTests
    {
        [TestMethod]
        public void TestIConsoleInjection()
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();

            // Act
            var socialNetworkConsoleApp = new SocialNetworkConsoleApp(consoleMock.Object);

            // Assert
            consoleMock.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Exactly(2));
            //consoleMock.Verify(m=> m.WriteLine("Welcome to Social Network!"),Times.Once);
            //consoleMock.Verify(m => m.WriteLine("Usage To post something: Alice: This is my dummy post!"), Times.Once);
        }
    }
}
