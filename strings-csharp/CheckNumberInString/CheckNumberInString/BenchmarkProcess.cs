using BenchmarkDotNet.Attributes;

namespace CheckNumberInString
{
    [MemoryDiagnoser(true)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkProcess
    {
        private const string inputString = "The price is $42.75 for two items and $18.50 for one item.";

        [Benchmark]
        public string ExtractNumberUsingRegExMethod()
        {
            return  ExtractNumber.ExtractNumberUsingRegEx(inputString).ToString();
        }

        [Benchmark]
        public string ExtractNumberUsingLinqMethod()
        {
            return ExtractNumber.ExtractNumbersUsingLinq(inputString).ToString();
        }

        [Benchmark]
        public string ExtractNumberUsingStringBuilderMethod()
        {
            return ExtractNumber.ExtractNumberUsingStringBuilder(inputString).ToString();
        }

        [Benchmark]
        public string ExtractNumberUsingSpanMethod()
        {
            return ExtractNumber.ExtractNumberUsingSpan(inputString).ToString();
        }
    }
}
