namespace DifferencesBetweenNUnitXUnitandMStest;

internal class Program
{
    static void Main(string[] args)
    {
        var additionResult = Calculator.Add(2, 3);
        Console.WriteLine($"The sum is {additionResult}");

        var subtractionResult = Calculator.Subtract(4, 3);
        Console.WriteLine($"The difference is {subtractionResult}");

        var multiplicationResult = Calculator.Multiply(2, 3);
        Console.WriteLine($"The product is {multiplicationResult}");
    }
}