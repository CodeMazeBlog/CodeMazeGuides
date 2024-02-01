using BenchmarkDotNet.Attributes;

namespace ReverseNumberAsInteger
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkReverseNumber
    {
        readonly int num = 123456789;

        [Benchmark]
        public void DigitExtractAndReconstruct_PositiveNum() => ReverseNumbers.ReverseUsingDigitExtractionAndReconstruction(num);

        [Benchmark]
        public void ModuloAndDivision_PositiveNum() => ReverseNumbers.ReverseUsingDigitExtractionAndReconstruction(num);

        [Benchmark]
        public void Recursion_PositiveNum() => ReverseNumbers.ReverseUsingRecursion(num);

        [Benchmark]
        public void MathPow_PositiveNum() => ReverseNumbers.ReverseUsingMathPow(num);

        [Benchmark]
        public void Linq_PositiveNum() => ReverseNumbers.ReverseUsingLinq(num);

        [Benchmark]
        public void ReverseAsString_LargePosNum() => ReverseLargeNumbers.ReverseAsString(num);

        [Benchmark]
        public void SwappingDigits_LargePosNum() => ReverseLargeNumbers.ReverseBySwappingDigits(num);


    }
}
