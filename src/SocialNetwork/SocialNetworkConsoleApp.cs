using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

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
            var runTask = Task.Run(() => this.RunAsync(CancellationToken.None));
            runTask.Wait();
        }

        public async Task RunAsync(CancellationToken token)
        {
            console.WriteLine("Welcome to Social Network!");
            console.WriteLine("Please, Login to start: Write your user name.");

            while (true)
            {
                token.ThrowIfCancellationRequested();

                var readLineTask = this.ReadLineAsync();
                await readLineTask;

                var input = readLineTask.Result;

                if (input == "exit")
                {
                    break;
                }
                else
                {
                    console.WriteLine($"Welcome {input}!");
                }
            }
        }

        private async Task<string> ReadLineAsync()
        {
            return await Task.Run(() => console.ReadLine());
        }
    }
}