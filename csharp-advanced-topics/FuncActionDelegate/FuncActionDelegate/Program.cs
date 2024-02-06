using System;
using System.Collections.Generic;
namespace FuncActionDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func Demo
            var funcSample = new FuncSample();
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine($"Sum of even numbers:{ funcSample.FilterAndSum(numbers)}");


            //Action Demo
            var actionSample = new ActionSample();
            List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
            actionSample.Greeting(names);
        }
    }
}
