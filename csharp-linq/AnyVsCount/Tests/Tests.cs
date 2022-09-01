using AnyVsCount;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly PerformanceBenchmark _benchmarkRunner;

        public Tests()
        {
            _benchmarkRunner = new PerformanceBenchmark();
        }

        [Fact]
        public void WhenCheckingWithAny_ThenReturnTrue()
        {
            var anyValue = _benchmarkRunner.CheckWithAny();

            Assert.True(anyValue);
        }

        [Fact]
        public void WhenCheckingWithCount_ThenReturnTrue()
        {
            var anyValue = _benchmarkRunner.CheckWithCount();

            Assert.True(anyValue);
        }

        [Fact]
        public void WhenCheckingWithAnyAndCondition_ThenReturnTrue()
        {
            var anyValueWithCodition = _benchmarkRunner.CheckWithAnyAndCondition();

            Assert.True(anyValueWithCodition);
        }

        [Fact]
        public void WhenCheckingWithCountAndCondition_ThenReturnTrue()
        {
            var anyValueWithCodition = _benchmarkRunner.CheckWithCountAndCondition();

            Assert.True(anyValueWithCodition);
        }

        [Fact]
        public void WhenCheckingWithCountProperty_ThenReturnTrue()
        {
            var anyValueWithCountProperty = _benchmarkRunner.CheckWithCountProperty();

            Assert.True(anyValueWithCountProperty);
        }
    }
}