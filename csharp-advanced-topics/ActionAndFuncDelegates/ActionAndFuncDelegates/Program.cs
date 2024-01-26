using System;

namespace ActionAndFuncDelegates
{
    public class Program
    {
        private readonly IConsoleWriter _consoleWriter;

        public Program(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        static void Main()
        {
            var program = new Program(new ConsoleWriter());
            program.ActionDelegate();
            program.FuncDelegate();
        }

        public void ActionDelegate()
        {
            Action<int, int> add = (x, y) =>
            {
                var result = x + y;
                _consoleWriter.WriteLine(result.ToString());
            };

            Action<string> greet = (name) =>
            {
                _consoleWriter.WriteLine($"Hello {name}");
            };

            add(9, 7);
            greet("Phil");
        }

        public int FuncDelegate()
        {
            Func<int, int, int> add = (x, y) => x + y;
            Func<string, int> stringLength = (s) => s.Length;

            var sum = add(9, 7);
            var length = stringLength("Hello World");

            _consoleWriter.WriteLine($"Sum: {sum}");
            _consoleWriter.WriteLine($"String Length: {length}");

            return sum; 
        }

    }

    public interface IConsoleWriter
    {
        void WriteLine(string message);
    }

    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
