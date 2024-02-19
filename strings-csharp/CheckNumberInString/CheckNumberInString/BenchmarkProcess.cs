using BenchmarkDotNet.Attributes;

namespace CheckNumberInString
{
    [MemoryDiagnoser(true)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkProcess
    {
        private int[] data;
        private const string inputString = "The total revenue is $123";

        [GlobalSetup]
        public void GlobalSetup()
        {
            data = Enumerable.Range(1, 1000).ToArray();
        }

        [Benchmark]
        public void RegularExpressionMethod()
        {
            for (int i = 0; i < data.Length; i++)
            {
                ExtractNumber.ExtractNumberUsingRegEx(inputString);
            }
        }

        [Benchmark]
        public void LinqAndCharIsDigitMethod()
        {
            for (int i = 0; i < data.Length; i++)
            {
                ExtractNumber.ExtractNumberUsingLinqAndCharIsDigit(inputString);
            }
        }
        [Benchmark]
        public void StringBuilderAndCharIsDigitMethod()
        {
            for (int i = 0; i < data.Length; i++)
            {
                ExtractNumber.ExtractNumberUsingStringBuilderAndCharIsDigit(inputString);
            }
        }
    }
}
