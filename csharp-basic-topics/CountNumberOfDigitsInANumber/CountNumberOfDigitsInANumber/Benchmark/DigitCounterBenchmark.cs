using BenchmarkDotNet.Attributes;

namespace CountNumberOfDigitsInANumber.Benchmark
{
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class DigitCounterBenchmark
    {
        [Params(-12345, -1234, -123, -12, -1, 0, 1, 12, 123, 1234, 12345)]
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
    }
}
