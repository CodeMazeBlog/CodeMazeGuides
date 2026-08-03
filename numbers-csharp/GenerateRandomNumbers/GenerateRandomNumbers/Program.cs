
using System.Security.Cryptography;

namespace GenerateRandomNumbers 
{
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
                run = input.ToLower().First().Equals('y') ? true : false;
            }
        }

        private static void GenerateNumbers()
        {
            var seed = 12;
            var lowerBound = Int32.MinValue;
            var upperBound = Int32.MaxValue;

            var pseduoNum = getPseudoRandomNumber();
            Console.WriteLine($"Pseduo Random Number Generated: {pseduoNum}");

            var pseduoSeedNum = getPseudoRandomNumberWithSeed(seed);
            Console.WriteLine($"Pseduo Random Number Generated with {seed} as the seed: {pseduoSeedNum}");

            var secureNum = getSecureRandomNumber(upperBound);
            Console.WriteLine($"Secure Random Number Generated with {upperBound} as the exclusive upper bound: {secureNum}");

            var pseduoNumWithinRange = getPseudoRandomNumberWithinRange(lowerBound, upperBound);
            Console.WriteLine($"Pseduo Random Number Generated with {lowerBound} as the inclusive lower bound and {upperBound} as the exclusive upper bound: {pseduoNumWithinRange}");

            var secureNumWithinRange = getSecureNumberWithinRange(lowerBound, upperBound);
            Console.WriteLine($"Secure Random Number Generated with {lowerBound} as the inclusive lower bound and {upperBound} as the exclusive upper bound: {secureNumWithinRange}");

            var pseduoDouble = getPseudoDouble();
            Console.WriteLine($"Pseduo Random Double Generated: {pseduoDouble}");

            var secureDouble = getSecureDouble();
            Console.WriteLine($"Secure Random Double Generated: {secureDouble}");
        }

        public static int getPseudoRandomNumber()
        {
            var random = new Random();
            var rNum = random.Next();
            return rNum;
        }

        public static int getPseudoRandomNumberWithSeed(int seed)
        {
            var random = new Random(seed);
            var rNum = random.Next();
            return rNum;
        }

        public static int getSecureRandomNumber(int upperBound)
        {
            RandomNumberGenerator.Create();
            var rngNum = RandomNumberGenerator.GetInt32(upperBound);
            return rngNum;
        }

        public static int getPseudoRandomNumberWithinRange(int lowerBound, int upperBound)
        {
            var random = new Random();
            var rNum = random.Next(lowerBound, upperBound);
            return rNum;
        }

        public static int getSecureNumberWithinRange(int lowerBound, int upperBound)
        {
            RandomNumberGenerator.Create();
            var rngNum = RandomNumberGenerator.GetInt32(lowerBound,upperBound);
            return rngNum;
        }

        public static double getPseudoDouble()
        {
            var random = new Random();
            var rDouble = random.NextDouble();
            return rDouble;
        }

        public static double getSecureDouble()
        {
            RandomNumberGenerator.Create();
            var numerator = RandomNumberGenerator.GetInt32(1, int.MaxValue);
            var denominator = RandomNumberGenerator.GetInt32(1, int.MaxValue);
            double quotient = (double) numerator / denominator;
            return quotient;
        }
    }
}