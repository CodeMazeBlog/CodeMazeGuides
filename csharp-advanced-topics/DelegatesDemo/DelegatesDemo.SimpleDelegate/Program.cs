using System;

namespace DelegatesDemo.SimpleDelegate
{
   public class Program
    {
        public delegate int CalculatorDelegate(int x, int y);
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number:");
            var firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            var secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select Calculation  Operation: add, subtract, multiply, divide");
            var operation = Console.ReadLine();

            int result = CalculatorOperation(firstNumber, secondNumber, operation);

            Console.WriteLine($"Result = {result}");

            Console.ReadKey();
        }

        public static int CalculatorOperation(int firstNumber, int secondNumber, string operation)
        {
            CalculatorDelegate calculation
               = operation switch
               {
                   "add" => (x, y) => x + y,
                   "subtract" => (x, y) => x - y,
                   "multiply" => (x, y) => x * y,
                   _ => (x, y) => y != 0 ? x / y : 0
               };

            return CalculateResult(firstNumber, secondNumber, calculation);
        }

        private static int CalculateResult(int firstNumber, int secondNumber, CalculatorDelegate calculation)
        {
            var result = calculation(firstNumber, secondNumber);
            return result;
           
        }
    }
}

