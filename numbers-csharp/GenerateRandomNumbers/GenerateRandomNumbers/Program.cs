
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

            var pseduoNumThreadSafe = getPseudoRandomNumberThreadSafe();
            Console.WriteLine($"Pseduo Random Thread-Safe Number Generated: {pseduoNumThreadSafe}");

            var pseduoDouble = getPseudoDouble();
            Console.WriteLine($"Pseduo Random Double Generated: {pseduoDouble}");

            var pseduoDoubleWithinRange = getPseudoDoubleWithinRange(lowerBound,upperBound);
            Console.WriteLine($"Pseduo Random Double Generated with {lowerBound} as the inclusive lower bound and {upperBound} as the exclusive upper bound: {pseduoDoubleWithinRange}");

            var secureDouble = getSecureDouble();
            Console.WriteLine($"Secure Random Double Generated: {secureDouble}");

            var secureDoubleWithinRange = getSecureDoubleWithinRange(lowerBound, upperBound);
            Console.WriteLine($"Secure Random Double Generated with {lowerBound} as the inclusive lower bound and {upperBound} as the exclusive upper bound: {secureDoubleWithinRange}");
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

        public static int getPseudoRandomNumberThreadSafe()
        {
            var random = Random.Shared.Next();
            return random;
        }

        public static double getPseudoDouble()
        {
            var random = new Random();
            var rDouble = random.NextDouble();
            return rDouble;
        }
        public static double getPseudoDoubleWithinRange(double lowerBound, double upperBound)
        {
            var random = new Random();
            var rDouble = random.NextDouble();
            var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
            return rRangeDouble;
        }

        public static double getSecureDouble()
        {
            RandomNumberGenerator.Create();
            var denominator = RandomNumberGenerator.GetInt32(2, int.MaxValue);
            double sDouble = (double) 1 / denominator;
            return sDouble;
        }
        public static double getSecureDoubleWithinRange(double lowerBound, double upperBound)
        {
            var rDouble = getSecureDouble();
            var rRangeDouble = (double) rDouble * (upperBound - lowerBound) + lowerBound;
            return rRangeDouble;
        }
    }
}