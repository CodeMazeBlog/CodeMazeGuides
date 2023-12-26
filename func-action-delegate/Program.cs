using System;

namespace func_action_delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> add = (a, b) =>
            {
                return a + b;
            };
            int result = add(5, 3);
            Console.WriteLine($"The addition result is: {result}");

            Action<string> greet = (name) =>
            {
                Console.WriteLine($"Hello, {name}!");
            };

            greet("John");
        }
    }
}
