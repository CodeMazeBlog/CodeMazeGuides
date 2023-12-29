using System;
using System.Collections.Generic;
using System.Linq;
namespace ActionAndFuncDelegatesTest
{
    public class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            // Print the numbers using Action delegate
            PrintNumbers(numbers);
            Console.WriteLine(); // New line for clarity
            // Calculate the sum of the numbers using Func delegate
            int sum = CalculateSum(numbers);
            Console.WriteLine($"Sum of the numbers: {sum}");
        }
        // Action delegate to print numbers
        public static void PrintNumbers(List<int> numbers)
        {
            Action<int> printNumber = (num) => Console.Write($"{num} ");
            numbers.ForEach(printNumber);
        }
        // Func delegate to calculate the sum of numbers
        public static int CalculateSum(List<int> numbers)
        {
            Func<int, int, int> add = (a, b) => a + b;
            return numbers.Aggregate(add);
        }
    }
}
