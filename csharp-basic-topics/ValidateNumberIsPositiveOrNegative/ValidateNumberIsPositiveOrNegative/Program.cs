using ValidateNumberIsPositiveOrNegative;

public class Program
{
    private static void Main(string[] args)
    {
        var number = -42;
        Console.WriteLine($"The function will return 1 if number is greater than zero, -1 if the number is less than zero, 0 if the number is equal to zero.");
        Console.WriteLine($"IsPositiveOrNegative Using Conditional Statement -> {NumberValidation.IsPositiveOrNegativeUsingConditionalMethod(number)} ");
        Console.WriteLine($"IsPositiveOrNegative Using Bitwise Operator RightShift -> {NumberValidation.IsPositiveOrNegativeUsingRightShiftMethod(number)} ");
        Console.WriteLine($"IsPositiveOrNegative Using Bitwise Operator LeftShift -> {NumberValidation.IsPositiveOrNegativeUsingLeftShiftMethod(number)} ");
        Console.WriteLine($"IsPositiveOrNegative Using MathAbs -> {NumberValidation.IsPositiveOrNegativeUsingMathAbsMethod(number)} ");
        Console.WriteLine($"IsPositiveOrNegative Using MathSign -> {NumberValidation.IsPositiveOrNegativeUsingMathSignMethod(number)} ");
        Console.WriteLine($"IsPositiveOrNegative Using IsPositive or IsNegative -> {NumberValidation.IsPositiveOrNegativeUsingBuiltInMethod(number)} ");
        //Todo : remove it 
        //Console.WriteLine($"Is negative {number}: {NumberValidation.IsNegativeShift(number)}");
        //Console.WriteLine($"Is negative {number}: {NumberValidation.IsNegativeShift(number)}");
    }

}