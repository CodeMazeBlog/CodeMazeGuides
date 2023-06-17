using ConstVsReadonlyInCSharp;

namespace Tests
{
    public class CircleCalculatorUnitTests
    {
        private CircleCalculator _circleCalculator = new CircleCalculator();

        [Fact]
        public void WhenCalculatingCircumferenceFor3_ThenReturn18_84()
        {
            var result = _circleCalculator.GetCircumference(3);

            Assert.Equal(18.84, result, 3);
        }

        [Fact]
        public void WhenCalculatingAccurateCircumferenceFor3_ThenReturn18_849555921540002()
        {
            var result = _circleCalculator.GetAccurateCircumference(3);

            Assert.Equal(18.849555921540002, result, 12);
        }
    }
}
