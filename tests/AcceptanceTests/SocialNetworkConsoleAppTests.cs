using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork;

namespace AcceptanceTests
{
    [TestClass]
    public class SocialNetworkConsoleAppTests
    {
        [TestMethod]
        public void WelcomeScreen_ShowsTwoLines()
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();
            var socialNetworkConsoleApp = new SocialNetworkConsoleApp(consoleMock.Object);

            // Act
            socialNetworkConsoleApp.Run();

            // Assert
            consoleMock.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void WelcomeScreen_ShowsWelcomeMessage()
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();
            var socialNetworkConsoleApp = new SocialNetworkConsoleApp(consoleMock.Object);

            // Act
            socialNetworkConsoleApp.Run();

            // Assert
            consoleMock.Verify(m => m.WriteLine("Welcome to Social Network!"), Times.Once);
        }

        [TestMethod]
        public void WelcomeScreen_ShowsHowToPost()
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();
            var socialNetworkConsoleApp = new SocialNetworkConsoleApp(consoleMock.Object);

            // Act
            socialNetworkConsoleApp.Run();

            // Assert
            consoleMock.Verify(m => m.WriteLine("Usage to post.. <Alice> This is my dummy post!"), Times.Once);
        }
    }
}
