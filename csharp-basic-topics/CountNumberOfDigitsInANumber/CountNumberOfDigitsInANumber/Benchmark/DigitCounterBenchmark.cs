using BenchmarkDotNet.Attributes;

namespace CountNumberOfDigitsInANumber.Benchmark
{
    public class DigitCounterBenchmark
    {
        private DigitCounter _digitCounter;

        [Params(-12345, -1234, -123, -12, -1, 0, 1, 12, 123, 1234, 12345)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _digitCounter = new DigitCounter();
        }

        [Benchmark]
        public int Iterative() => _digitCounter.GetIterativeCount(N);

        [Benchmark]
        public int Recursive() => _digitCounter.GetRecursiveCount(N);

        [Benchmark]
        public int Log10() => _digitCounter.GetLog10Count(N);

        [Benchmark]
        public int String() => _digitCounter.GetStringLengthCount(N);

        [Benchmark]
        public int IfChain() => _digitCounter.GetIfChainCount(N);
    }
}
