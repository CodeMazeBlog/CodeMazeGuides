using System.Security.Cryptography;

namespace GenerateRandomNumbers;

public class Program
{
    public static void Main(string[] args)
    {
        var pseudoDouble = GetPseudoDouble();
        Console.WriteLine($"Pseudorandom double: {pseudoDouble}");

        var pseudoDoubleWithinRange = GetPseudoDoubleWithinRange(16, 30000);
        Console.WriteLine($"Pseudorandom double between 16 and 30000: {pseudoDoubleWithinRange}");

        var secureDouble = GetSecureDouble();
        Console.WriteLine($"Secure double: {secureDouble}");

        var secureDoubleWithinRange = GetSecureDoubleWithinRange(4, 123000);
        Console.WriteLine($"Secure double between 4 and 123000: {secureDoubleWithinRange}");

        ShowEdgeCases();
    }

    public static double GetPseudoDouble()
    {
        var rDouble = Random.Shared.NextDouble();
        return rDouble;
    }

    public static double GetPseudoDoubleWithinRange(double lowerBound, double upperBound)
    {
        var rDouble = Random.Shared.NextDouble();
        var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
        return rRangeDouble;
    }

    public static double GetPseudoDoubleBelowUpperBound(double lowerBound, double upperBound)
    {
        var rRangeDouble = GetPseudoDoubleWithinRange(lowerBound, upperBound);
        return rRangeDouble < upperBound ? rRangeDouble : Math.BitDecrement(upperBound);
    }

    public static double GetPseudoDoubleWithinWideRange(double lowerBound, double upperBound)
    {
        var rDouble = Random.Shared.NextDouble();
        var rRangeDouble = rDouble * upperBound + (1 - rDouble) * lowerBound;
        return rRangeDouble;
    }

    public static double GetSecureDouble()
    {
        var numerator = RandomNumberGenerator.GetInt32(int.MaxValue);
        var sDouble = (double)numerator / int.MaxValue;
        return sDouble;
    }

    public static double GetSecureDoubleWithinRange(double lowerBound, double upperBound)
    {
        var rDouble = GetSecureDouble();
        var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
        return rRangeDouble;
    }

    public static void ShowEdgeCases()
    {
        var largest = Math.BitDecrement(1.0);
        Console.WriteLine(largest);
        Console.WriteLine(largest * (2.0 - 1.0) + 1.0);

        Console.WriteLine(GetPseudoDoubleWithinRange(double.MinValue, double.MaxValue));
    }
}
