using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of integers
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Define a Func delegate to filter numbers (e.g., keep only even numbers)
        Func<int, bool> isEven = n => n % 2 == 0;

        // Use LINQ to filter and sum the even numbers
        int sumOfEvens = numbers.Where(isEven).Sum();

        // Output the result
        Console.WriteLine("Sum of even numbers: " + sumOfEvens);
    }
}