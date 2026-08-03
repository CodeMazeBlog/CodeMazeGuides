using System;
namespace CallerMethod.Test
{
    public class ConsoleCapture : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOutput;

        public ConsoleCapture()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _stringWriter.Dispose();
        }

        public override string ToString() => _stringWriter.ToString();
    }
}

