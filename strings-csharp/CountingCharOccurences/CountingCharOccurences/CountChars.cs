using BenchmarkDotNet.Attributes;
using System.Text.RegularExpressions;

namespace CountingCharOccurences
{
    public class CountChars
    {
        private static readonly string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static readonly Random _random = new Random();

        public static IEnumerable<List<string>> GenerateStringWithSubString()
        {
            var data = new List<List<string>>();

            var needleHaystack = new List<string>();

            int length = _random.Next(5, 1000);
            char[] haystack = GenerateRandomString(length);

            int needleLength = _random.Next(2, Math.Min(100, length));
            char[] needle = GenerateRandomString(needleLength);

            needleHaystack.Add(Convert.ToString(haystack));
            needleHaystack.Add(Convert.ToString(needle));

            data.Add(needleHaystack);

            return data;
        }

        public static IEnumerable<List<string>> GenerateStringWithChar()
        {
            var data = new List<List<string>>();

            var needleHaystack = new List<string>();

            int length = _random.Next(5, 1000);
            char[] haystack = GenerateRandomString(length);

            char needle = GenerateRandomString(1)[0];

            needleHaystack.Add(Convert.ToString(haystack));
            needleHaystack.Add(Convert.ToString(needle));

            data.Add(needleHaystack);

            return data;
        }

        private static char[] GenerateRandomString(int length)
        {
            var word = new char[length];

            for (int i = 0; i < word.Length; i++)
            {
                word[i] = _chars[_random.Next(_chars.Length)];
            }

            return word;
        }

        [ArgumentsSource(nameof(GenerateStringWithChar))]
        [Benchmark]
        public int CountCharsUsingLinqCount(List<string> text)
        {
            string mainString = text[0];
            char toFind = Convert.ToChar(text[1]);

            return mainString.Count(t => t == toFind);
        }

        [ArgumentsSource(nameof(GenerateStringWithChar))]
        [Benchmark]
        public int CountCharsUsingForeach(List<string> text)
        {
            int count = 0;
            string mainString = text[0];
            char toFind = Convert.ToChar(text[1]);

            foreach (var c in mainString)
            {
                if (c == toFind)
                    count++;
            }

            return count;
        }

        [ArgumentsSource(nameof(GenerateStringWithChar))]
        [Benchmark]
        public int CountCharsUsingForeachSpan(List<string> text)
        {
            int count = 0;
            string mainString = text[0];
            char toFind = Convert.ToChar(text[1]);

            foreach (var c in mainString.AsSpan())
            {
                if (c == toFind)
                    count++;
            }

            return count;
        }

        [ArgumentsSource(nameof(GenerateStringWithChar))]
        [Benchmark]
        public int CountCharsUsingIndex(List<string> text)
        {
            int count = 0;
            int n = 0;
            string mainString = text[0];
            char toFind = Convert.ToChar(text[1]);

            while ((n = mainString.IndexOf(toFind, n) + 1) != 0)
            {
                n++;
                count++;
            }

            return count;
        }

        [ArgumentsSource(nameof(GenerateStringWithChar))]
        [Benchmark]
        public int CountCharsUsingFor(List<string> text)
        {
            int count = 0;
            char toFind = Convert.ToChar(text[1]);
            char[] textChars = text[0].ToCharArray();
            int length = textChars.Length;

            for (int n = 0; n < length; n++)
            {
                if (textChars[n] == toFind)
                    count++;
            }

            return count;
        }

        [ArgumentsSource(nameof(GenerateStringWithChar))]
        [Benchmark]
        public int CountCharsUsingForReverseIteration(List<string> text)
        {
            int count = 0;
            char toFind = Convert.ToChar(text[1]);
            char[] textChars = text[0].ToCharArray();
            int length = textChars.Length;

            for (int n = length - 1; n >= 0; n--)
            {
                if (textChars[n] == toFind)
                    count++;
            }

            return count;
        }

        [ArgumentsSource(nameof(GenerateStringWithSubString))]
        [Benchmark]
        public int CountCharsUsingSplit(List<string> text)
        {
            string mainString = text[0];
            string toFind = text[1];

            return mainString.Split(toFind).Length - 1;
        }

        [ArgumentsSource(nameof(GenerateStringWithSubString))]
        [Benchmark]
        public int CountCharsUsingReplace(List<string> text)
        {
            string mainString = text[0];
            string toFind = text[1];

            return (mainString.Length - mainString.Replace(toFind, "").Length) / toFind.Length;
        }

        [ArgumentsSource(nameof(GenerateStringWithSubString))]
        [Benchmark]
        public int CountCharsUsingRegex(List<string> text)
        {
            string mainString = text[0];
            string toFind = text[1];

            return new Regex(Regex.Escape(toFind)).Matches(mainString).Count;
        }
    }
}
