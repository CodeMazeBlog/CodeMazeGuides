
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
            var lowerBound = Int32.MinValue;
            var upperBound = Int32.MaxValue;

            var pseduoDouble = GetPseudoDouble();
            Console.WriteLine($"Pseduo Random Double Generated: {pseduoDouble}");

            var pseduoDoubleWithinRange = GetPseudoDoubleWithinRange(lowerBound, upperBound);
            Console.WriteLine($"Pseduo Random Double Generated with {lowerBound} as the inclusive lower bound and {upperBound} as the exclusive upper bound: {pseduoDoubleWithinRange}");

            var secureDouble = GetSecureDouble();
            Console.WriteLine($"Secure Random Double Generated: {secureDouble}");

            var secureDoubleWithinRange = GetSecureDoubleWithinRange(lowerBound, upperBound);
            Console.WriteLine($"Secure Random Double Generated with {lowerBound} as the inclusive lower bound and {upperBound} as the exclusive upper bound: {secureDoubleWithinRange}");
        }

        public static double GetPseudoDouble()
        {
            var random = new Random();
            var rDouble = random.NextDouble();
            return rDouble;
        }
        public static double GetPseudoDoubleWithinRange(double lowerBound, double upperBound)
        {
            var random = new Random();
            var rDouble = random.NextDouble();
            var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
            return rRangeDouble;
        }

        public static double GetSecureDouble()
        {
            RandomNumberGenerator.Create();
            var denominator = RandomNumberGenerator.GetInt32(2, int.MaxValue);
            double sDouble = (double) 1 / denominator;
            return sDouble;
        }
        public static double GetSecureDoubleWithinRange(double lowerBound, double upperBound)
        {
            var rDouble = GetSecureDouble();
            var rRangeDouble = (double)rDouble * (upperBound - lowerBound) + lowerBound;
            return rRangeDouble;
        }
    }
}