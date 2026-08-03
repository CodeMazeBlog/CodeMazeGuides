using SealedClasses;
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
        public void GivenSealedClass_WhenReturningInt_ThenGreaterThanZero()
        {
            var intValue = _benchmarkRunner.Sealed_IntMethod();

            Assert.True(intValue > 0);
        }

        [Fact]
        public void GivenOpenClass_WhenReturningInt_ThenGreaterThanZero()
        {
            var intValue = _benchmarkRunner.Open_IntMethod();

            Assert.True(intValue > 0);
        }

        [Fact]
        public void GivenSealedClass_WhenReturningToString_ThenLengthGreaterThanZero()
        {
            var stringValue = _benchmarkRunner.Sealed_ToString();

            Assert.True(stringValue.Length > 0);
        }

        [Fact]
        public void GivenOpenClass_WhenReturningToString_ThenLengthGreaterThanZero()
        {
            var stringValue = _benchmarkRunner.Open_ToString();

            Assert.True(stringValue.Length > 0);
        }

        [Fact]
        public void GivenSealedClass_WhenCheckingTypeOfParent_ThenReturnFalse()
        {
            var isSealedClass = _benchmarkRunner.Sealed_TypeCheck();

            Assert.False(isSealedClass);
        }

        [Fact]
        public void GivenOpenClass_WhenCheckingTypeOfParent_ThenReturnFalse()
        {
            var isOpenClass = _benchmarkRunner.Open_TypeCheck();

            Assert.False(isOpenClass);
        }
    }
}