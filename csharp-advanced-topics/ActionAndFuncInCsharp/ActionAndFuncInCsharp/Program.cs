using System;
using ActionAndFuncInCsharp.Fruit;

namespace ActionAndFuncInCsharp
{
    public class Program
    {
        public static Action<double, double> reporter;
        public static Func<double, double, double> aggregator;
        public static IEnumerable<IFruit> allCitrusFruits;

        public static void Main()
        {
            // simple Action<> example

            reporter = new Action<double, double>(ReportProfits);

            var aggregatedSales = 1000000.00;
            var aggregatedExpenses = 12340.00;

            reporter(aggregatedSales, aggregatedExpenses);

            // Action<> set by lambda example

            reporter = (grossSales, totalExpenses) => Console.WriteLine($"Profit: ${grossSales - totalExpenses}");

            reporter(aggregatedSales, aggregatedExpenses);

            // Action<> set by anonymous function

            reporter
                = delegate (double grossSales, double totalExpenses) { Console.WriteLine($"Profit: ${grossSales - totalExpenses}"); };

            reporter(aggregatedSales, aggregatedExpenses);

            // simple Func<> example

            double CalculateProfits(double grossSales, double totalExpenses)
            {
                return grossSales - totalExpenses;
            }

            aggregator = new Func<double, double, double>(CalculateProfits);

            Console.WriteLine($"Profit: ${aggregator(aggregatedSales, aggregatedExpenses)}");

            // Func<> set by lambda example

            var carSales = 564894.02;
            var truckSales = 1515868.44;

            Func<double, double, double> salesAggregator = (a, b) => a + b;

            Console.WriteLine($"All vehicle sales: ${salesAggregator(carSales, truckSales)}");

            // Func<> set by anonymous function

            aggregator = delegate (double a, double b) { return a + b; };

            Console.WriteLine($"All vehicle sales: ${aggregator(carSales, truckSales)}");

            // real world example of Func<> used in LINQ

            var fruits = new List<IFruit>() { new Apple(), new Banana(), new Orange() };

            // in this case Where() signature is: Where(Func<IFruit, bool>)
            allCitrusFruits = fruits.Where(fruit => fruit.isCitrus); // allCitrusFruits should now only be a collection containing 'Orange'
        }

        public static void ReportProfits(double grossSales, double totalExpenses)
        {
            Console.WriteLine($"Profit: ${grossSales - totalExpenses}");
        }
    }
}
