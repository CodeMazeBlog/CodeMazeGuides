using BenchmarkDotNet.Attributes;
using System;
using System.Numerics;

namespace ReverseNumberAsInteger
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkReverseLargeNumber
    {
        readonly BigInteger largeInt = BigInteger.Parse("-919293847576943309435893857695833");

        [Benchmark]
        public void DigitExtractAndReconstruct_LargePosNum() => ReverseLargeNumbers.ReverseUsingDigitExtractionAndReconstruction(largeInt);

        [Benchmark]
        public void Recursion_LargePosNum() => ReverseLargeNumbers.ReverseUsingRecursion(largeInt);

        [Benchmark]
        public void MathPow_LargePosNum() => ReverseLargeNumbers.ReverseUsingMathPow(largeInt);

        [Benchmark]
        public void SwappingDigits_LargePosNum() => ReverseLargeNumbers.ReverseBySwappingDigits(largeInt);

        [Benchmark]
        public void Linq_LargePosNum() => ReverseLargeNumbers.ReverseUsingLinq(largeInt);

        [Benchmark]
        public void ReverseAsString_LargePosNum() => ReverseLargeNumbers.ReverseAsString(largeInt);
    }

    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkReverseVeryLargeNumber
    {
        readonly BigInteger veryLargeInt = BigInteger.Parse("50559192938475769654984549875464987846498798454888888888888888888888888898498451849849849879846546548798498484784848748741849898321654656546651651654984765110000545487485468489645443309435893857695833");

        [Benchmark]
        public void DigitExtractAndReconstruct_200DigitNumber() => ReverseLargeNumbers.ReverseUsingDigitExtractionAndReconstruction(veryLargeInt);

        [Benchmark]
        public void Recursion_200DigitNumber() => ReverseLargeNumbers.ReverseUsingRecursion(veryLargeInt);

        [Benchmark]
        public void MathPow_200DigitNumber() => ReverseLargeNumbers.ReverseUsingMathPow(veryLargeInt);

        [Benchmark]
        public void SwappingDigits_200DigitNumber() => ReverseLargeNumbers.ReverseBySwappingDigits(veryLargeInt);

        [Benchmark]
        public void Linq_200DigitNumber() => ReverseLargeNumbers.ReverseUsingLinq(veryLargeInt);

        [Benchmark]
        public void ReverseAsString_200DigitNumber() => ReverseLargeNumbers.ReverseAsString(veryLargeInt);
    }
}