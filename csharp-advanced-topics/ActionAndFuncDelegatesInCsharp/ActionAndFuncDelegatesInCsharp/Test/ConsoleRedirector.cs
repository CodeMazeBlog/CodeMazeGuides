using System;
using System.IO;

namespace Test
{
    internal class ConsoleRedirector : IDisposable
    {
        private StringWriter _consoleOutput = new StringWriter();
        private TextWriter _originalConsoleOutput;
        public ConsoleRedirector()
        {
            this._originalConsoleOutput = Console.Out;
            Console.SetOut(_consoleOutput);
        }
        public void Dispose()
        {
            Console.SetOut(_originalConsoleOutput);
            Console.Write(this.ToString());
            this._consoleOutput.Dispose();
        }
        public override string ToString()
        {
            return this._consoleOutput.ToString();
        }
    }
}
