using ConstVsReadonlyInCSharp;

namespace Tests
{
    public class MathCalculatorUnitTests
    {
        private MathCalculator _mathCalculator = new MathCalculator();

        [Fact]
        public void WhenAdding1And3_TheReturn4()
        {
            var result = _mathCalculator.Add(1, 3);

            Assert.Equal(4.0M, result, 1);
        }

        [Fact]
        public void WhenSubtracting5And3_TheReturn2()
        {
            var result = _mathCalculator.Subtract(5, 3);

            Assert.Equal(2.0M, result, 1);
        }

        [Fact]
        public void WhenMultiplying10And3_TheReturn30()
        {
            var result = _mathCalculator.Multiply(10, 3);

            Assert.Equal(30.0M, result, 1);
        }

        [Fact]
        public void WhenDividing10And5_TheReturn2()
        {
            var result = _mathCalculator.Divide(10, 5);

            Assert.Equal(2.0M, result, 1);
        }
    }
}
