using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public interface IConsole
    {
        void WriteLine(string value);

        string ReadLine();
    }
}
