using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorsInCSharp.Tests
{
    public class ConsoleOutputTester : IDisposable
    {
        private StringWriter consoleOutput;
        private TextWriter originalOutput;

        public ConsoleOutputTester()
        {
            consoleOutput = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(consoleOutput);
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            consoleOutput.Dispose();
        }

        public string GetOutput()
        {
            return consoleOutput.ToString();
        }
    }
}
