public class Program
{
    private static void Main(string[] args)
    {
        int number = -42;
        IsPositiveOrNegative_ConditionalMethod(number);
        IsPositiveOrNegative_RightShiftMethod(number);
        IsPositiveOrNegative_LeftShiftMethod(number);
        IsPositiveOrNegative_MathAbsMethod(number);
        IsPositiveOrNegative_MathSignMethod(number);
        IsPositiveOrNegative(number);

    }
    public static void IsPositiveOrNegative_ConditionalMethod(int number)
    {
        //int number = 60;

        if (number > 0)
        {
            Console.WriteLine($"IsPositiveOrNegative_ConditionalMethod - {number} is positive number.");
        }
        else if (number < 0)
        {
            Console.WriteLine($"IsPositiveOrNegative_ConditionalMethod - {number} is negative number.");
        }
        else
        {
            Console.WriteLine($"IsPositiveOrNegative_ConditionalMethod - The {number} is zero.");
        }
    }
    public static void IsPositiveOrNegative_LeftShiftMethod(int number)
    {
        // Using left shift operator to check the sign bit
        if ((number & (1 << 31)) == 0)
        {
            Console.WriteLine($"IsPositiveOrNegative_LeftShiftMethod - {number} is a positive number (using Left shift).");
        }
        else
        {
            Console.WriteLine($"IsPositiveOrNegative_LeftShiftMethod - {number} is a negative number (using left shift).");
        }
    }
    public static void IsPositiveOrNegative_RightShiftMethod(int number)
    {
        // Using right shift operator to check the sign bit
        if ((number >> 31) == 0)
        {
            Console.WriteLine($"IsPositiveOrNegative_RightShiftMethod - {number} is a positive number (using right shift).");
        }
        else
        {
            Console.WriteLine($"IsPositiveOrNegative_RightShiftMethod - {number} is a negative number (using right shift).");
        }
    }
    public static void IsPositiveOrNegative_MathAbsMethod(int number)
    {
        int absoluteValue = Math.Abs(number);

        if (absoluteValue == number)
        {
            Console.WriteLine($"IsPositiveOrNegative_MathAbsMethod - {number} is a positive number.");
        }
        else
        {
            Console.WriteLine($"IsPositiveOrNegative_MathAbsMethod - {number} is a negative number.");
        }
    }
    public static void IsPositiveOrNegative_MathSignMethod(int number)
    {
        int sign = Math.Sign(number);

        if (sign == 1)
        {
            Console.WriteLine($"IsPositiveOrNegative_MathSignMethod - {number} is a positive number.");
        }
        else if (sign == -1)
        {
            Console.WriteLine($"IsPositiveOrNegative_MathSignMethod - {number} is a negative number.");
        }
        else
        {
            Console.WriteLine($"IsPositiveOrNegative_MathSignMethod - The {number} is zero.");
        }
    }
    public static void IsPositiveOrNegative(int number)
    {
        bool isPositive = Int32.IsPositive(number);
        bool isNegative = Int32.IsNegative(number);

        if (isPositive)
        {
            Console.WriteLine($"IsPositiveOrNegative - The {number} is positive.");
        }
        if (isNegative)
        {
            Console.WriteLine($"IsPositiveOrNegative - The {number} is negative.");
        }
    }
}