using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace SpanExample
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<StringSpanBenchmark>();
        }
    }

    [MemoryDiagnoser]
    public class StringSpanBenchmark
    {
        string hamletText = File.ReadAllText("./hamletActOne.txt");

        // string func
        [Benchmark]
        public void ParseWithString()
        {
            string[] hamletlines = hamletText.Split('\n');
        }

        // span func
        [Benchmark]
        public void ParseWithSpan()
        {
            var hamletSpan = hamletText.AsSpan();

            int indexPrev = 0;
            int indexCurrent = 0;
            foreach (char c in hamletSpan)
            {
                if (c == '\n')
                {
                    var slice = hamletSpan.Slice(indexPrev + 1, indexCurrent - indexPrev);
                    indexPrev = indexCurrent;
                }
                indexCurrent++;
            }
        }

        private string[] getAllWords(string text)
        {
            MatchCollection matches = Regex.Matches(text, @"\b[\w']+\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select m.Value;

            return words.ToArray();
        }
    }
}