using BenchmarkDotNet.Attributes;
using System.Text.RegularExpressions;

namespace CountingCharOccurences
{
    public class CountChars
    {
        public IEnumerable<object[]> GenerateStringWithCharArgs()
        {
            yield return new object[] { "Mary had a little lamb", 'l' };
        }

        public IEnumerable<object[]> GenerateStringWithStringArgs()
        {
            yield return new object[] { "Mary had a little lamb", "Mary" };
            yield return new object[] { "Mary had a little lamb", "l" };
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingLinqCount(string source, char toFind)
        {
            return source.Count(t => t == toFind);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingForeach(string source, char toFind)
        {
            int count = 0;

            foreach (var ch in source)
            {
                if (ch == toFind)
                    count++;
            }

            return count;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingForeachSpan(string source, char toFind)
        {
            int count = 0;

            foreach (var c in source.AsSpan())
            {
                if (c == toFind)
                    count++;
            }

            return count;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingIndex(string source, char toFind)
        {
            int count = 0;
            int n = 0;

            while ((n = source.IndexOf(toFind, n) + 1) != 0)
            {
                n++;
                count++;
            }

            return count;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingFor(string source, char toFind)
        {
            int count = 0;

            for (int n = 0; n < source.Length; n++)
            {
                if (source[n] == toFind)
                    count++;
            }

            return count;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingForReverseIteration(string source, char toFind)
        {
            int count = 0;

            for (int n = source.Length - 1; n >= 0; n--)
            {
                if (source[n] == toFind)
                    count++;
            }

            return count;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingForWithSpan(string source, char toFind)
        {
            int count = 0;

            for (int n = 0; n < source.AsSpan().Length; n++)
            {
                if (source[n] == toFind)
                    count++;
            }

            return count;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithStringArgs))]
        public int CountCharsUsingSplit(string source, string toFind)
        {
            return source.Split(toFind).Length - 1;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithStringArgs))]
        public int CountCharsUsingReplace(string source, string toFind)
        {
            return (source.Length - source.Replace(toFind, "").Length) / toFind.Length;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithStringArgs))]
        public int CountCharsUsingRegex(string source, string toFind)
        {
            return new Regex(Regex.Escape(toFind)).Matches(source).Count;
        }
    }
}
