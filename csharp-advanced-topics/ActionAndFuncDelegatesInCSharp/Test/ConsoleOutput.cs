using System;
using System.IO;

namespace TestProject1
{
    // Helper class to capture Console output
    public class ConsoleOutput : IDisposable
    {
        private StringWriter _stringWriter;
        private TextWriter _originalOutput;

        public ConsoleOutput()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public string GetOutput()
        {
            return _stringWriter.ToString().Trim();
        }

        public void Dispose()
        {
            _stringWriter.Dispose();
            Console.SetOut(_originalOutput);
        }
    }
}
