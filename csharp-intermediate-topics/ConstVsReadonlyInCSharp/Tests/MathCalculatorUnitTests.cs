using ConstVsReadonlyInCSharp;

namespace Tests
{
    public class MathCalculatorUnitTests
    {
        private MathCalculator mathCalculator = new MathCalculator();

        [Fact]
        public void WhenAdding1And3_TheReturn4()
        {
            var result = mathCalculator.Add(1, 3);

            Assert.Equal(4, result);
        }

        [Fact]
        public void WhenSubstracting5And3_TheReturn2()
        {
            var result = mathCalculator.Substract(5, 3);

            Assert.Equal(2, result);
        }

        [Fact]
        public void WhenMultiplying10And3_TheReturn30()
        {
            var result = mathCalculator.Multiply(10, 3);

            Assert.Equal(30, result);
        }

        [Fact]
        public void WhenDividing10And5_TheReturn2()
        {
            var result = mathCalculator.Divide(10, 5);

            Assert.Equal(2, result);
        }
    }
}
