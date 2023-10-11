using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorsInCSharp.Tests
{
    public sealed class ConsoleOutputTester : IDisposable
    {
        private readonly StringWriter _consoleOutput = new();
        private readonly TextWriter _originalOutput;

        public ConsoleOutputTester()
        {
            _consoleOutput.NewLine = "\n";
            _originalOutput = Console.Out;
            Console.SetOut(_consoleOutput);
        }

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _consoleOutput.Dispose();
        }

        public string GetOutput() => _consoleOutput.ToString();
    }
}
