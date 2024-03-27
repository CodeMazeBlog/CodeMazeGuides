using BenchmarkDotNet.Attributes;

namespace CheckNumberInString
{
    [MemoryDiagnoser()]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkProcess
    {
        private const string InputString = "The price is $42.75 for two items and $18.50 for one item.";

        [Benchmark]
        public string ExtractNumberUsingRegExMethod()
        {
            return  ExtractNumber.ExtractNumberUsingRegEx(InputString);
        }

        [Benchmark]
        public string ExtractNumberUsingLinqMethod()
        {
            return ExtractNumber.ExtractNumbersUsingLinq(InputString);
        }

        [Benchmark]
        public string ExtractNumberUsingStringBuilderMethod()
        {
            return ExtractNumber.ExtractNumberUsingStringBuilder(InputString);
        }

        [Benchmark]
        public string ExtractNumberUsingSpanMethod()
        {
            return ExtractNumber.ExtractNumberUsingSpan(InputString);
        }
    }
}
