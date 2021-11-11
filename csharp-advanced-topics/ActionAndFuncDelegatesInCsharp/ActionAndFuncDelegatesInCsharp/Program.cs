using System;

namespace ActionAndFuncDelegatesInCsharp
{
    public delegate double CalculationDelegate(double x, double y);

    public class Program
    {
        public static double Sum(double x, double y) => x + y;
        public static double Multiply(double x, double y) => x * y;

        static void Main(string[] args)
        {
            CalculationDelegate operation = Sum;
            PrintResult(operation, 2, 5);

            PrintResult(Multiply, 2, 5);

            CalculationDelegate divide = (x , y) => x / y;
            PrintResult(divide, 10, 2); // This case will show a strange name as the Method Name because the divide delegate objet is anonymous

            Action doSomething = HelloWorld;
            doSomething();

            Func<DateTime> dateTimeYesterday = () => DateTime.Now.AddDays(-1);
            Console.WriteLine("Yesterday was {0}", dateTimeYesterday().ToShortDateString());

            Func<double, DateTime> dateTimeBackwards = (daysBackwards) => DateTime.Now.AddDays(-daysBackwards);
            var daysAgo = 5d;
            Console.WriteLine("{0} days ago was {1}", daysAgo, dateTimeBackwards(daysAgo).ToShortDateString());
        }

        public static void PrintResult(CalculationDelegate operation, double x, double y)
        {
            Console.WriteLine("{0}({1}, {2}) = {3}", operation.Method.Name, x, y, operation(x, y));
        }

        public static void HelloWorld() => Console.WriteLine("Hello World");
    }

}
