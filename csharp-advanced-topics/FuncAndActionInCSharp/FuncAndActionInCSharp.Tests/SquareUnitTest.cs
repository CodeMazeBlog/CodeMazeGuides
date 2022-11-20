using FuncAndActionInCSharp.Shapes;

namespace FuncAndActionInCSharp.Tests
{
    public class SquareUnitTest
    {
        int side;

        [Fact]
        public void WhenCalculateSquareArea_ThenReturnCorrectValue()
        {
            side = 25;
            double expectedAreaValue = 625;
            double actualAreaValue = Square.GetSquareArea(side);

            Assert.Equal(expectedAreaValue, actualAreaValue);
        }

        [Fact]
        public void WhenCalculatePerimeterArea_ThenReturnCorrectValue()
        {
            side = 30;
            double expectedAreaValue = 120;
            double actualAreaValue = Square.GetSquarePerimeter(side);

            Assert.Equal(expectedAreaValue, actualAreaValue);
        }
    }
}