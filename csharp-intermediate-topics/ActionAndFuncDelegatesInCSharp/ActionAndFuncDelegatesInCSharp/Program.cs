using System;
using System.Collections.Generic;

namespace ActionAndFuncDelegates
{
    class Program
    {
        // Function to check if a number is even
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // Action to double and print a number
        public static void DoubleNumber(int number)
        {
            Console.WriteLine($"Double of {number} is: {number * 2}");
        }

        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Using Func delegate to check if a number is even
            Func<int, bool> isEvenDelegate = IsEven;

            foreach (var number in numbers)
            {
                bool result = isEvenDelegate(number);
                Console.WriteLine($"{number} is even: {result}");
            }

            // Using Action delegate to double and print numbers
            Action<int> doubleAndPrint = DoubleNumber;

            Console.WriteLine("\nUsing Action Delegate to Double Numbers:");
            numbers.ForEach(doubleAndPrint);
        }
    }
}
