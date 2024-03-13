using BenchmarkDotNet.Attributes;

namespace CountNumberOfDigitsInANumber.Benchmark
{
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class DigitCounterBenchmark
    {
        [Params(-1234567890, -12345, 0, 12345, 1234567890)]
        public int N;

        [Benchmark]
        public int Iterative() => DigitCounter.GetIterativeCount(N);

        [Benchmark]
        public int Recursive() => DigitCounter.GetRecursiveCount(N);

        [Benchmark]
        public int Log10() => DigitCounter.GetLog10Count(N);

        [Benchmark]
        public int String() => DigitCounter.GetStringLengthCount(N);

        [Benchmark]
        public int IfChain() => DigitCounter.GetIfChainCount(N);

        [Benchmark]
        public int BitManipulation() => DigitCounter.GetBitManipulationCount(N);

        [Benchmark]
        public int Fast() => DigitCounter.GetFastCount(N);
    }
}
