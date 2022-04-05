

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
            var pseduoNum = GetPseudoRandomNumber();
            Console.WriteLine($"Pseduo Random Number Generated: {pseduoNum}");

            var pseduoDouble = GetPseudoDouble();
            Console.WriteLine($"Pseduo Random Double Generated: {pseduoDouble}");

            var threadSafePseduoNum = GetPseudoRandomNumberThreadSafe();
            Console.WriteLine($"Threadsafe Pseduo Random Double Generated: {threadSafePseduoNum}");

            var stringLength = 10;
            var pseduoRandomString = GetPseudoRandomString(stringLength);
            Console.WriteLine($"Threadsafe Pseduo Random String Generated: {pseduoRandomString}");

            var rc = new RandomCustom();
            var customAlgorithmPsuedoRandomNumber = rc.Next();
            Console.WriteLine($"Custom Algorithm Psuedo Random Number: {customAlgorithmPsuedoRandomNumber}");
        }

        public static int GetPseudoRandomNumber()
        {
            var random = new Random();
            var rNum = random.Next();

            return rNum;
        }
        public static double GetPseudoDouble()
        {
            var random = new Random();
            var rDouble = random.NextDouble();

            return rDouble;
        }
        public static int GetPseudoRandomNumberThreadSafe()
        {
            var random = Random.Shared.Next();

            return random;
        }

        public static string GetPseudoRandomString(int stringLength)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var pseudoRandomChars = new char[stringLength];

            for (int i = 0; i < stringLength; ++i)
            {
                int charIndex = random.Next(alphabet.Length);
                pseudoRandomChars[i] = alphabet[charIndex];
            }

            var pseudoRandomString = new string(pseudoRandomChars);

            return pseudoRandomString;
        }
    }
}