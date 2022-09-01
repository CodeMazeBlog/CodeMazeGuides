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
        public void WhenCheckingIfAnyWithAny_ThenReturnTrue()
        {
            var anyValue = _benchmarkRunner.CheckIfAnyWithAny();

            Assert.True(anyValue);
        }

        [Fact]
        public void WhenCheckingIfAnyWithCount_ThenReturnTrue()
        {
            var anyValue = _benchmarkRunner.CheckIfAnyWithCount();

            Assert.True(anyValue);
        }

        [Fact]
        public void WhenCheckingIfAnyWithAnyAndCondition_ThenReturnTrue()
        {
            var anyValueWithCodition = _benchmarkRunner.CheckIfAnyWithAnyAndCondition();

            Assert.True(anyValueWithCodition);
        }

        [Fact]
        public void WhenCheckingIfAnyWithCountAndCondition_ThenReturnTrue()
        {
            var anyValueWithCodition = _benchmarkRunner.CheckIfAnyWithCountAndCondition();

            Assert.True(anyValueWithCodition);
        }

        [Fact]
        public void WhenCheckingIfAnyWithCountProperty_ThenReturnTrue()
        {
            var anyValueWithCountProperty = _benchmarkRunner.CheckIfAnyWithCountProperty();

            Assert.True(anyValueWithCountProperty);
        }
    }
}