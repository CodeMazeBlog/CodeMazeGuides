using System;

namespace ActionAndFuncDelegatesInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> getRoot =
                (double value) => Math.Sqrt(value);
            Func<double, double> getSquare =
                (double value) => Math.Pow(value, 2);

            Console.WriteLine("Enter value:");
            var value = 0.0;
            double.TryParse(Console.ReadLine(), out value);

            Console.WriteLine("{0} squared is {1}.", value, Methods.GetProcessResult(value, getSquare));
            Console.WriteLine("Square root of {0} is {1}.", value, Methods.GetProcessResult(value, getRoot));
        }
    }
}
