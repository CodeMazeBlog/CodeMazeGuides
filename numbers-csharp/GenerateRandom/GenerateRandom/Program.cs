
using System.Security.Cryptography;

namespace GenerateRandom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var run = true;
            while (run)
            {
                GenerateRandomData();
                Console.WriteLine("\n Run Again? (Y/N)");
                var input = Console.ReadLine() ?? "";
                run = input.ToLower().First().Equals('y') ? true : false;
            }
        }

        private static void GenerateRandomData()
        {
            var pseduoNum = getPseudoRandomNumber();
            Console.WriteLine($"Pseduo Random Number Generated: {pseduoNum}");

            var pseduoDouble = getPseudoDouble();
            Console.WriteLine($"Pseduo Random Double Generated: {pseduoDouble}");

            var threadSafePseduoNum = getPseudoRandomNumberThreadSafe();
            Console.WriteLine($"Threadsafe Pseduo Random Double Generated: {threadSafePseduoNum}");

            int stringLength = 10;
            var pseduoRandomString = getPseudoRandomString(stringLength);
            Console.WriteLine($"Threadsafe Pseduo Random String Generated: {pseduoRandomString}");

            var rc = new RandomCustom();
            var customAlgorithmPsuedoRandomNumber = rc.Next();
            Console.WriteLine($"Custom Algorithm Psuedo Random Number: {customAlgorithmPsuedoRandomNumber}");
        }

        public static int getPseudoRandomNumber()
        {
            var random = new Random();
            var rNum = random.Next();
            return rNum;
        }
        public static double getPseudoDouble()
        {
            var random = new Random();
            var rDouble = random.NextDouble();
            return rDouble;
        }
        public static int getPseudoRandomNumberThreadSafe()
        {
            var random = Random.Shared.Next();
            return random;
        }

        public static string getPseudoRandomString(int stringLength)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var pseudoRandomChars = new char[stringLength];

            for (int i = 0; i < stringLength; ++i)
            {
                int charIndex = random.Next(alphabet.Length);
                pseudoRandomChars[i] = alphabet[charIndex];
            }

            var pseudoRandomString = new String(pseudoRandomChars);
            return pseudoRandomString;
        }

        public class RandomCustom : Random
        {
            protected override double Sample()
            {
                return modifySample(base.Sample());
            }

            private double modifySample(double sample)
            {
                double newSample = Math.Log(sample);
                return newSample;
            }

            public override int Next()
            {
                return (int)(Sample() * int.MaxValue);
            }
        }
    }
}