using System;

namespace ActionAndFuncDelegates
{
    public class Calculator
    {
        // Define an Action delegate that takes two integers as input parameters
        public static Action<int, int> AddNumbers = (x, y) => Console.WriteLine($"The sum of {x} and {y} is: {x + y}");

        // Define a Func delegate that takes two integers as input parameters and returns their sum
        public static Func<int, int, int> SumDelegate = (a, b) => a + b;

        static void Main(string[] args)
        {
            // Invoke the Action delegate with two integer values
            AddNumbers(10, 20);

            // Call the method represented by the Func delegate and print the result
            int sum = SumDelegate(5, 10);
            Console.WriteLine($"The sum of 5 and 10 is: {sum}");

            Console.ReadKey();
        }

    }
}
