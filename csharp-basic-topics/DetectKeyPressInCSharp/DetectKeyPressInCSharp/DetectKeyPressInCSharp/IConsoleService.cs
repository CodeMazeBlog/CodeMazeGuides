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

    public class ConsoleService : IConsoleService
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public ConsoleKeyInfo ReadKey(bool intercept = false)
        {
            return Console.ReadKey(intercept);
        }

        public bool KeyAvailable
        {
            get
            {
                return Console.KeyAvailable;
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
