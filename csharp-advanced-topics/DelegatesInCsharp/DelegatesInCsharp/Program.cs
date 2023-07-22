using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> printSquare = (x) =>
            {
                int square = x * x;
                Console.WriteLine(square);
            };

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            numbers.ForEach(printSquare);

            List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5 };

            Func<int, bool> isEven = (x) => x % 2 == 0;

            List<int> evenNumbers = numbers1.Where(isEven).ToList();

            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }
    }
}
