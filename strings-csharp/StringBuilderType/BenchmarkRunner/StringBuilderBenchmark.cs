using BenchmarkDotNet.Attributes;
using StringBuilderType;
using System.Text;

namespace BenchmarkRunner
{    
    [MemoryDiagnoser]
    public class StringBuilderBenchmark
    {
        public static readonly StringBuilderMethods stringBuilderMethods = new StringBuilderMethods();

        [Benchmark]
        public void AppendWithStringBuilder()
        {
            var stringBuilder = new StringBuilder("1234");

            for (int i = 0; i < 1000; i++)
            {
                stringBuilder.Append(i.ToString());
            }
        }

        [Benchmark]
        public void AppendWithString()
        {
            var arg = "1234";

            for (int i = 0; i < 1000; i++)
            {
                arg += i.ToString();
            }
        }

        [Benchmark]
        public void InsertWithStringBuilder()
        {
            var sb = new StringBuilder("0");

            for (int i = 1; i <= 1000; i++)
            {
                sb.Insert(i, "0");
            }
        }

        [Benchmark]
        public void InsertWithString()
        {
            var arg = "0";

            for (int i = 1; i <= 1000; i++)
            {
                arg = arg.Insert(i, "0");
            }
        }

        [Benchmark]
        public void RemoveWithStringBuilder()
        {
            var sampleLetters = RandomString(2000);
            var sb = new StringBuilder(sampleLetters);

            for (int i = 0; i < 100; i++)
            {
                sb.Remove(1, 2);
            }
        }

        [Benchmark]
        public void RemoveWithString()
        {
            var sampleLetters = RandomString(2000);

            for (int i = 0; i < 100; i++)
            {
                sampleLetters = sampleLetters.Remove(1, 2);
            }
        }

        [Benchmark]
        public void ReplaceWithStringBuilder()
        {
            var sampleLetters = RandomString(2000);
            var sb = new StringBuilder(sampleLetters);

            for (int i = 0; i < 100; i++)
            {
                var letter = sampleLetters[i];
                sb.Replace(letter, '0');
            }
        }

        [Benchmark]
        public void ReplaceWithString()
        {
            var sampleLetters = RandomString(2000);

            for (int i = 0; i < 100; i++)
            {
                var letter = sampleLetters[i];
                sampleLetters = sampleLetters.Replace(letter, '0');
            }
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
