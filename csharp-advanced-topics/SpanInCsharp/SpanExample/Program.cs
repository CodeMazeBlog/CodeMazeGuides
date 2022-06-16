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
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class StringSpanBenchmark
    {
        string _hamletText = File.ReadAllText("./hamletActOne.txt");

        // string func
        [Benchmark]
        public void ParseWithString()
        {
            var indexPrev = 0;
            var indexCurrent = 0;
            var substrings = new List<string>();
            foreach (char c in _hamletText)
            {
                if (c == '\n')
                {
                    indexCurrent += 1;
                    substrings.Add(
                        _hamletText.Substring(
                            indexPrev, 
                            indexCurrent - indexPrev));
                    indexPrev = indexCurrent;
                    continue;
                }
                indexCurrent++;
            }
        }

        // span func
        [Benchmark]
        public void ParseWithSpan()
        {
            var hamletSpan = _hamletText.AsSpan();

            var indexPrev = 0;
            var indexCurrent = 0;
            foreach (char c in hamletSpan)
            {
                if (c == '\n')
                {
                    indexCurrent += 1;
                    var slice = hamletSpan.Slice(
                        indexPrev,
                        indexCurrent - indexPrev);
                    indexPrev = indexCurrent;
                    continue;
                }
                indexCurrent++;
            }
        }
    }
}