using System;
using System.Linq;

namespace ActionAndFuncDelegates.Funcs
{
    class ZeroParameterFunc
    {
        public static void Test()
        {
            Func<string> randomStringGenerator;

            randomStringGenerator = RandomStringGeneratorWithLetters;
            string randomLetters = randomStringGenerator();
            Console.WriteLine(randomLetters);
            //randomStringGenerator can represent any function which returns a string without parameter so both RandomStringGeneratorWithLetters and RandomStringGeneratorWithDigits is acceptable for it
            randomStringGenerator = RandomStringGeneratorWithDigits;
            string randomDigits = randomStringGenerator();
            Console.WriteLine(randomDigits);
        }

        static string RandomStringGeneratorWithLetters()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static string RandomStringGeneratorWithDigits()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
