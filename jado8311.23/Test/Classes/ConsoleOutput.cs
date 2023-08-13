using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Classes
{
    public class ConsoleOutput : IDisposable
    {
        private readonly TextWriter originalOutput;
        private readonly StringWriter consoleOutput;

        public ConsoleOutput()
        {
            originalOutput = Console.Out;
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        public string GetOutput()
        {
            return consoleOutput.ToString() ?? string.Empty;
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            consoleOutput.Dispose();
        }
    }
}