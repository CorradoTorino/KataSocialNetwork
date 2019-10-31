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
            console.WriteLine("a");
            console.WriteLine("b");
        }
    }
}