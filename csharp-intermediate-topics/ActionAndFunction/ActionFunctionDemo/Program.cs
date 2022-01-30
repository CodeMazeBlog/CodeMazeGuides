using System;

namespace ActionFunctionDemo
{
    public class Program
    {
        // 1. Func //
        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        // 2. Action //
        public static void DisplayName(string nameOfPerson)
        {
            Console.WriteLine(nameOfPerson);
        }

        static void Main(string[] args)
        {
            // 1. Func - Execution
            Func<int, int, int> multiplyDelegate = Multiply;
            Console.WriteLine(multiplyDelegate(2, 5));

            // 2. Action - Execution
            Action<string> writeDelegate = DisplayName;
            writeDelegate("Rebecca Jay");
        }
    }
}