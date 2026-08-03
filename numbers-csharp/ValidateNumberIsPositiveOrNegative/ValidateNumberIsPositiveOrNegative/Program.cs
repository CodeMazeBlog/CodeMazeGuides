using BenchmarkDotNet.Running;
using ValidateNumberIsPositiveOrNegative;

public class Program
{
    private static void Main(string[] args)
    {
        var number = -42L;
        Console.WriteLine($"The function will return 1 if number is greater than zero, -1 if the number is less than zero, 0 if the number is equal to zero.");
        Console.WriteLine($"IsPositiveOrNegative Using Conditional Statement {number} -> {NumberValidation.IsPositiveOrNegativeUsingConditionalMethod(number)} ");
        Console.WriteLine($"IsPositiveOrNegative Using Bitwise Operator RightShift {number} -> {NumberValidation.IsPositiveOrNegativeUsingRightShiftMethod(number)} ");
        Console.WriteLine($"IsPositiveOrNegative Using Bitwise Operator LeftShift {number} -> {NumberValidation.IsPositiveOrNegativeUsingLeftShiftMethod(number)} ");
        Console.WriteLine($"IsPositiveOrNegative Using MathAbs {number} -> {NumberValidation.IsPositiveOrNegativeUsingMathAbsMethod(number)} ");
        Console.WriteLine($"IsPositiveOrNegative Using MathSign {number} -> {NumberValidation.IsPositiveOrNegativeUsingMathSignMethod(number)} ");
        Console.WriteLine($"IsPositiveOrNegative Using IsPositive or IsNegative {number} -> {NumberValidation.IsPositiveOrNegativeUsingBuiltInMethod(number)} ");
        //BenchmarkRunner.Run<BenchmarkTester>();
    }
}