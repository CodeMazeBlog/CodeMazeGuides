using System;
using System.Collections.Generic;
using System.Linq;
namespace Action_and_Func_Delegates_test
{
    public class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            PrintNumbers(numbers);
            Console.WriteLine(); // New line for clarity

            int sum = CalculateSum(numbers);
            Console.WriteLine($"Sum of the numbers: {sum}");
        }

        public static void PrintNumbers(List<int> numbers)
        {
            Action<int> printNumber = (num) => Console.Write($"{num} ");
            numbers.ForEach(printNumber);
        }

        public static int CalculateSum(List<int> numbers)
        {
            Func<int, int, int> add = (a, b) => a + b;
            return numbers.Aggregate(add);
        }
    }
}
