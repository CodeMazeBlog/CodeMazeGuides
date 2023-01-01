using FuncAndActionInCSharp.Shapes;

namespace FuncAndActionInCSharp.Tests
{
    public class RectangleUnitTest
    {
        int length, width;

        [Fact]
        public void WhenCalculateRectangleArea_ThenReturnCorrectValue()
        {
            length = 15;
            width = 20;
            double expectedAreaValue = 300;
            double actualAreaValue = Shapes.Rectangle.GetRectangleArea(length, width);

            Assert.Equal(expectedAreaValue, actualAreaValue);
        }

        [Fact]
        public void WhenCalculateRectanglePerimeter_ThenReturnCorrectValue()
        {
            length = 15;
            width = 20;
            double expectedAreaValue = 70;
            double actualAreaValue = Shapes.Rectangle.GetRectanglePerimeter(length, width);

            Assert.Equal(expectedAreaValue, actualAreaValue);
        }
    }
}