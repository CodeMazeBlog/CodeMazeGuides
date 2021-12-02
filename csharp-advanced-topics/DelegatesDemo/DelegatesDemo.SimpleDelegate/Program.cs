using System;

namespace DelegatesDemo.SimpleDelegate
{
    class Program
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

            CalculatorDelegate calculation 
                = operation switch
                  {
                     "add" => (x, y) => x + y,
                     "subtract" => (x, y) => x - y,
                     "multiply" => (x, y) => x * y,
                      _=> (x, y) => y != 0 ? x / y : 0
                  };
          
            CalculateResult(firstNumber, secondNumber, calculation);
            
            Console.ReadKey();
        }

        private static void CalculateResult(int firstNumber, int secondNumber, CalculatorDelegate calculation)
        {
            var result = calculation(firstNumber, secondNumber);
            Console.WriteLine($"Result = {result}");
        }
    }
}

