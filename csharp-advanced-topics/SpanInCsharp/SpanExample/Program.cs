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
        string _hamletText = File.ReadAllText("./hamletActOne.txt");

        // string func
        [Benchmark]
        public void ParseWithString()
        {
            int indexPrev = 0;
            int indexCurrent = 0;
            List<string> substrings = new List<string>();
            foreach (char c in _hamletText)
            { 
                if (c == '\n')
                {
                    string substring = _hamletText.Substring(indexPrev == 0 ? indexPrev : indexPrev + 1, indexCurrent - indexPrev);
                    substrings.Add(substring);
                }
            }
        }

        // span func
        [Benchmark]
        public void ParseWithSpan()
        {
            var hamletSpan = _hamletText.AsSpan();

            int indexPrev = 0;
            int indexCurrent = 0;
            foreach (char c in hamletSpan)
            {
                if (c == '\n')
                {
                    var slice = hamletSpan.Slice(indexPrev == 0 ? indexPrev : indexPrev + 1, indexCurrent - indexPrev);
                    indexPrev = indexCurrent;
                }
                indexCurrent++;
            }
        }
    }
}