using BenchmarkDotNet.Attributes;

namespace ReverseNumberAsInteger
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [HideColumns(["Job", "Error", "StdDev", "Median"])]
    [RankColumn]
    public class BenchmarkReverseNumber
    {
        readonly int num = 123456789;

        [Benchmark]
        public void DigitExtractAndReconstruct_Int() => ReverseNumbers.ReverseUsingDigitExtractionAndReconstruction(num);

        [Benchmark]
        public void Recursion_Int() => ReverseNumbers.ReverseUsingRecursion(num);

        [Benchmark]
        public void MathPow_Int() => ReverseNumbers.ReverseUsingMathPow(num);

        [Benchmark]
        public void SwappingDigits_Int() => ReverseNumbers.ReverseBySwappingDigits(num);

        [Benchmark (Baseline = true)]
        public void ReverseAsString_Int() => ReverseLargeNumbers.ReverseAsString(num);
    }
}
