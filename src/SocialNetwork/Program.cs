using System;

namespace SocialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleApp = new SocialNetworkConsoleApp(new SystemConsoleWrapper());
            consoleApp.Run();
        }
    }
}
