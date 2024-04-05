using BaselineStylingInBenchmarkDotNet;

namespace Tests
{
    public class BaselineStylingTests
    {
        private readonly int _expectedSum = 2001000;
        private readonly BaselineStylingBenchmark _baselineStylingBenchmark = new();

        [Fact]
        public void WhenUseForLoopIsCalledThenReturnsTheCorrectSum()
        {
            var result = _baselineStylingBenchmark.UseForLoop();

            Assert.Equal(_expectedSum, result);
        }

        [Fact]
        public void WhenUseWhileLoopIsCalledThenReturnsTheCorrectSum()
        {
            var result = _baselineStylingBenchmark.UseWhileLoop();

            Assert.Equal(_expectedSum, result);
        }

        [Fact]
        public void WhenUseEnumerableSumIsCalledThenReturnsTheCorrectSum()
        {
            var result = _baselineStylingBenchmark.UseEnumerableSum();

            Assert.Equal(_expectedSum, result);
        }
    }
}