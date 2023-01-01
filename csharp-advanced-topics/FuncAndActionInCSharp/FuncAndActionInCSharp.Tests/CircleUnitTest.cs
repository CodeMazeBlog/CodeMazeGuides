using FuncAndActionInCSharp.Shapes;

namespace FuncAndActionInCSharp.Tests
{
    public class CircleUnitTest
    {
        int radius;

        [Fact]
        public void WhenCalculateCircleArea_ThenReturnCorrectValue()
        {
            radius = 15;
            double expectedAreaValue = 706.8583470577034;
            double actualAreaValue = Circle.GetCircleArea(radius);

            Assert.Equal(expectedAreaValue, actualAreaValue);
        }
    }
}