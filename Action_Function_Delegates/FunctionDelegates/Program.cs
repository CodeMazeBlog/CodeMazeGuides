using System;

namespace FunctionDelegates
{
    public static class Program
    {
        public static string SumTwoValue(int number1, int number2)
        {
            int result = number1 + number2;
            if (result % 2 == 0)
            {
                return "Even";
            }
            else
            {
                return "Odd";
            }
        }
        public static void Main(string[] args)
        {
            // Assign SumTwoValue function to Func<>
            Func<int, int, string> AddTwoValue = SumTwoValue;
            Console.WriteLine(AddTwoValue(20, 10));

            // Assign to anonymous method
            Func<string> hellowWorldStrings = delegate ()
            {
                return "Hello World";
            };
            Console.WriteLine(hellowWorldStrings());

            // Lambda Expression
            Func<string, string, string> CreateSentences = (x, y) => x + y;

            Console.WriteLine(CreateSentences("Hello", "Vahidal"));
        }
    }
}
