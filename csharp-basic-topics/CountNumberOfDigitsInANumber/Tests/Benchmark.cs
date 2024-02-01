using BenchmarkDotNet.Running;
using CountNumberOfDigitsInANumber.Benchmark;

namespace Tests
{
    [TestClass]
    public class Benchmark
    {
        [TestMethod]
        public void DigitCounterBenchmark()
        {
            var summary = BenchmarkRunner.Run<DigitCounterBenchmark>();
        }

        [TestMethod]
        public void DigitCounterLog10Benchmark()
        {
            var summary = BenchmarkRunner.Run<DigitCounterLog10Benchmark>();
        }

        [TestMethod]
        public void DigitCounterIfChainBenchmark()
        {
            var summary = BenchmarkRunner.Run<DigitCounterIfChainBenchmark>();
        }

        [TestMethod]
        public void DigitCounterStringBenchmark()
        {
            var summary = BenchmarkRunner.Run<DigitCounterStringBenchmark>();
        }

        [TestMethod]
        public void DigitCounterIterativeBenchmark()
        {
            var summary = BenchmarkRunner.Run<DigitCounterIterativeBenchmark>();
        }

        [TestMethod]
        public void DigitCounterRecursiveBenchmark()
        {
            var summary = BenchmarkRunner.Run<DigitCounterRecursiveBenchmark>();
        }
    }
}
