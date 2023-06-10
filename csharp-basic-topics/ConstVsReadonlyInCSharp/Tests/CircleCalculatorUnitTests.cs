using ConstVsReadonlyInCSharp;

namespace Tests
{
    public class CircleCalculatorUnitTests
    {
        private CircleCalculator circleCalculator = new CircleCalculator();

        [Fact]
        public void WhenCalculatingCerconferenceFor3_ThenReturn18_84()
        {
            var result = circleCalculator.GetCerconference(3);

            Assert.Equal(18.84, result);
        }

        [Fact]
        public void WhenCalculatingAccurateCerconferenceFor3_ThenReturn18_849555921540002()
        {
            var result = circleCalculator.GetAccurateCerconference(3);

            Assert.Equal(18.849555921540002, result);
        }
    }
}
