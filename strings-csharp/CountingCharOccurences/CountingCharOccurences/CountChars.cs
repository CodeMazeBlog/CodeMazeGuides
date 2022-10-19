using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Text.RegularExpressions;
using CommunityToolkit.HighPerformance;

namespace CountingCharOccurences
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Alphabetical)]
    [MemoryDiagnoser]
    public class CountChars
    {
        public IEnumerable<object[]> GenerateStringWithCharArgs()
        {
            yield return new object[] { "Mary had a little lamb", 'l' };
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
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingSplit(string source, char toFind)
        {
            return source.Split(toFind).Length - 1;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingReplace(string source, char toFind)
        {
            return source.Length - source.Replace(toFind.ToString(), "").Length;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingRegex(string source, char toFind)
        {
            return new Regex(Regex.Escape(toFind.ToString())).Matches(source).Count;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GenerateStringWithCharArgs))]
        public int CountCharsUsingSpanCount(string source, char toFind)
        {
            return source.AsSpan().Count(toFind);
        }
    }
}
