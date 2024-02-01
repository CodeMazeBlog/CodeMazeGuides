using BenchmarkDotNet.Attributes;

namespace CountNumberOfDigitsInANumber.Benchmark
{
    public class DigitCounterLog10Benchmark
    {
        private DigitCounter _digitCounter;

        [Params(0, 1, 12, 123, 1234, 12345, 123456, 1234567, 12345678, 123456789, 1234567890)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _digitCounter = new DigitCounter();
        }

        [Benchmark]
        public int Log10() => _digitCounter.GetLog10Count(N);
    }
}
