using System;

namespace ActionandFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Action delegate example
            Action<string> printAction = PrintMessage;
            printAction("Hello, World!");

            // Func delegate example
            Func<int, int, int> addFunc = AddNumbers;
            int result = addFunc(5, 10);

            Console.WriteLine("Result of addition: " + result);
            
        }

        // Method for printing a message
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Method for adding two numbers
       public static int AddNumbers(int a, int b)
        {
            return a + b;
        }
    }
}
