namespace Delegates
{
    class Program
    {
        static class MultiplicationUtility
        {
            public static double MultiplyTwoNumbers(double a, double b) => a * b;
        }

        static class ConsolePrinter
        {
            public static void PrintString(double num1, double num2) =>
                Console.WriteLine($"The values are: {num1} and {num2}");
        }

        static void Main(string[] args)
        {
            Action<double, double> printNumbers = ConsolePrinter.PrintString;
            printNumbers(2, 3); // The values are: 2 and 3

            Func<double, double, double> multiply = MultiplicationUtility.MultiplyTwoNumbers;
            Console.WriteLine(multiply(2, 3)); // 6
        }
    }
}