using System;

namespace ActionAndFuncDelegates
{
    public class Program
    {
        private readonly IConsoleWriter consoleWriter;

        public Program(IConsoleWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter;
        }

        static void Main()
        {
            var program = new Program(new ConsoleWriter());
            program.ActionDelegate();
            program.FuncDelegate();
        }

        //Demonstrate Action delegate
        public void ActionDelegate()
        {
            Action<int, int> add = (x, y) =>
            {
                int result = x + y;
                consoleWriter.WriteLine(result.ToString());
            };
            Action<string> greet = (name) =>
            {
                consoleWriter.WriteLine($"Hello {name}");
            };

            add(9, 7);
            greet("Phil");
        }

        //Demonstrate Func delegate
        public int FuncDelegate()
        {
            Func<int, int, int> add = (x, y) => x + y;
            Func<string, int> stringLength = (s) => s.Length;
            int sum = add(9, 7);
            int length = stringLength("Hello World");
            consoleWriter.WriteLine($"Sum: {sum}");
            consoleWriter.WriteLine($"String Length: {length}");
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
