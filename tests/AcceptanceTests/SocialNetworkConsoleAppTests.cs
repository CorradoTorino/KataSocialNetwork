using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
            consoleMock.Setup(m => m.ReadLine()).Returns("exit");

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
            consoleMock.Setup(m => m.ReadLine()).Returns("exit");

            // Act
            socialNetworkConsoleApp.Run();

            // Assert
            consoleMock.Verify(m => m.WriteLine("Welcome to Social Network!"), Times.Once);
        }

        [TestMethod]
        public void WelcomeScreen_ShowsLoginRequest()
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();
            var socialNetworkConsoleApp = new SocialNetworkConsoleApp(consoleMock.Object);
            consoleMock.Setup(m => m.ReadLine()).Returns("exit");

            // Act
            socialNetworkConsoleApp.Run();

            // Assert
            consoleMock.Verify(m => m.WriteLine("Please, Login to start: Write your user name."), Times.Once);
        }

        [TestMethod]
        public void WelcomeScreen_AfterLogin_TheUserIsWelcome()
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();
            var socialNetworkConsoleApp = new SocialNetworkConsoleApp(consoleMock.Object);
            using var semaphore = new ManualResetEvent(false);
            
            var errorOccurred = false;
            var readLines = 0;
            consoleMock.Setup(m => m.ReadLine()).
                Returns(() =>
                {
                    switch (readLines)
                    {
                        case 0:
                            readLines++;
                            return "Alice";
                        case 1:
                            readLines++;
                            semaphore.Set();
                            return "exit";
                        default:
                            errorOccurred = true;
                            return "";
                    }
                });

            // Act
            Task.Run(() => socialNetworkConsoleApp.RunAsync(CancellationToken.None));

            // Assert
            semaphore.WaitOne();
            Assert.IsFalse(errorOccurred);
            consoleMock.Verify(m => m.WriteLine("Welcome Alice!"), Times.Once);

        }
    }
}
