using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string? value)
        {
            Console.WriteLine(value);
        }
    }
}
