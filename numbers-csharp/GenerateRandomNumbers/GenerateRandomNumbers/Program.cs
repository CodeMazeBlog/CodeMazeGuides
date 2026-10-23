using System.Security.Cryptography;

namespace GenerateRandomNumbers;

public class Program
{
    public static void Main(string[] args)
    {
        var run = true;
        while (run)
        {
            GenerateNumbers();
            Console.WriteLine("\n Run Again? (Y/N)");
            var input = Console.ReadLine() ?? "";
            run = input.StartsWith('y') || input.StartsWith('Y');
        }
    }

    private static void GenerateNumbers()
    {
        var seed = 12;
        var lowerBound = 1;
        var upperBound = 6;

        var pseudoNum = GetPseudoRandomNumber();
        Console.WriteLine($"Pseudo Random Number Generated: {pseudoNum}");

        var pseudoSeedNum = GetPseudoRandomNumberWithSeed(seed);
        Console.WriteLine($"Pseudo Random Number Generated with {seed} as the seed: {pseudoSeedNum}");

        var secureNum = GetSecureRandomNumber(upperBound);
        Console.WriteLine($"Secure Random Number Generated with {upperBound} as the exclusive upper bound: {secureNum}");

        var pseudoNumWithinRange = GetPseudoRandomNumberWithinRange(lowerBound, upperBound);
        Console.WriteLine($"Pseudo Random Number Generated with {lowerBound} as the inclusive lower bound and {upperBound} as the exclusive upper bound: {pseudoNumWithinRange}");

        var pseudoNumInclusive = GetPseudoRandomNumberInclusive(lowerBound, upperBound);
        Console.WriteLine($"Pseudo Random Number Generated with {lowerBound} and {upperBound} as inclusive bounds: {pseudoNumInclusive}");

        var pseudoLong = GetPseudoRandomLongWithinRange(5_000_000_000, 6_000_000_000);
        Console.WriteLine($"Pseudo Random Long Generated between 5,000,000,000 and 6,000,000,000: {pseudoLong}");

        var secureNumWithinRange = GetSecureNumberWithinRange(lowerBound, upperBound);
        Console.WriteLine($"Secure Random Number Generated with {lowerBound} as the inclusive lower bound and {upperBound} as the exclusive upper bound: {secureNumWithinRange}");

        var pseudoDouble = GetPseudoDouble();
        Console.WriteLine($"Pseudo Random Double Generated: {pseudoDouble}");
    }

    public static int GetPseudoRandomNumber() => Random.Shared.Next();

    public static int GetPseudoRandomNumberWithSeed(int seed)
    {
        var random = new Random(seed);

        return random.Next();
    }

    public static int GetSecureRandomNumber(int upperBound) =>
        RandomNumberGenerator.GetInt32(upperBound);

    public static int GetPseudoRandomNumberWithinRange(int lowerBound, int upperBound) =>
        Random.Shared.Next(lowerBound, upperBound);

    public static int GetPseudoRandomNumberInclusive(int lowerBound, int upperBound) =>
        (int)Random.Shared.NextInt64(lowerBound, (long)upperBound + 1);

    public static long GetPseudoRandomLongWithinRange(long lowerBound, long upperBound) =>
        Random.Shared.NextInt64(lowerBound, upperBound);

    public static int GetSecureNumberWithinRange(int lowerBound, int upperBound) =>
        RandomNumberGenerator.GetInt32(lowerBound, upperBound);

    public static double GetPseudoDouble() => Random.Shared.NextDouble();
}
