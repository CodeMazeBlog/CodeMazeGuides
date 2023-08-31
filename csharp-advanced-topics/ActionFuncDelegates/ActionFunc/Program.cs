using System;

namespace ActionFunc;

class Program
{
    static void Main(string[] args)
    {
        // Action delegate example
        Action<string> printMessage = message => Console.WriteLine(message);
        printMessage("Welcome to the Michael Schneider Advanced Calculator!");

        // Func delegate examples
        Func<double, double, double> add = (a, b) => a + b;
        Func<double, double, double> subtract = (a, b) => a - b;
        Func<double, double, double> multiply = (a, b) => a * b;
        Func<double, double, double> divide = (a, b) => b != 0 ? a / b : double.NaN;

        Console.Write("Enter the first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.Write("Enter the operation number: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        double result = 0;

        switch (choice)
        {
            case 1:
                result = add(num1, num2);
                break;
            case 2:
                result = subtract(num1, num2);
                break;
            case 3:
                result = multiply(num1, num2);
                break;
            case 4:
                result = divide(num1, num2);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("Cannot divide by zero!");
                    return;
                }
                break;
            default:
                Console.WriteLine("Invalid operation!");
                return;
        }

        Console.WriteLine($"Result: {result}");
    }
}
