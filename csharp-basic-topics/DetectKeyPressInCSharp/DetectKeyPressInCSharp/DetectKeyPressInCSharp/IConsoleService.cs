using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectKeyPressInCSharp
{
    public interface IConsoleService
    {
        void WriteLine(string message);
        ConsoleKeyInfo ReadKey(bool intercept = false);
        bool KeyAvailable { get; }
        void Clear();
    }

}
