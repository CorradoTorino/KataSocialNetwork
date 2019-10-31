namespace SocialNetwork
{
    public class SocialNetworkConsoleApp
    {
        private readonly IConsole console;

        public SocialNetworkConsoleApp(IConsole console)
        {
            this.console = console;
        }

        public void Run()
        {
            console.WriteLine("Welcome to Social Network!");
            console.WriteLine("Usage to post.. <Alice> This is my dummy post!");
        }
    }
}