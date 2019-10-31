using System.Collections.Generic;
using System.Text;

namespace SocialNetwork
{
    public interface IConsole
    {
        void WriteLine(string value);

        string ReadLine();
    }
}
