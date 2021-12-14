using System;

namespace DelegatesDemo.ActionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number:");
            var firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            var secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select Calculation  Operation: add, subtract, multiply, divide");
            var operation = Console.ReadLine();

            CalculatorOperation(firstNumber, secondNumber, operation);

            Console.ReadKey();
        }

        public static void CalculatorOperation(int firstNumber, int secondNumber, string operation)
        {
            Action<int, int> calculation
                = operation switch
                {
                    "add" => (x, y) => Console.WriteLine(x + y),
                    "subtract" => (x, y) => Console.WriteLine(x - y),
                    "multiply" => (x, y) => Console.WriteLine(x * y),
                    _ => (x, y) => Console.WriteLine(y != 0 ? x / y : 0)
                };

            CalculateResult(firstNumber, secondNumber, calculation);
        }

        private static void CalculateResult(int firstNumber, int secondNumber, Action<int,int> calculation)
        {
            calculation(firstNumber, secondNumber);
            Console.WriteLine("Action has been processed!!");
        }
    }
}
