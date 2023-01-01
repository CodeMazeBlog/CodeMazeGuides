using FuncAndActionInCSharp.Shapes;

namespace FuncAndActionInCSharp.Tests
{
    public class FuncUnitTest
    {
        [Fact]
        public void GivenFuncWithOneIntInputParamAndOneDoubleOutParam_WhenCalculateSquareArea_ThenReturnCorrectValue()
        {
            Func<int, double> funcSquareArea = Square.GetSquareArea;
            var expectedAreaValue = 100;

            Assert.Equal(expectedAreaValue, funcSquareArea(10));
        }

        [Fact]
        public void GivenFuncWithOneIntInputParamAndOneDoubleOutParam_WhenCalculateSquarePerimeter_ThenReturnCorrectValue()
        {
            Func<int, double> funcSquarePerimeter = Square.GetSquarePerimeter;
            var expectedPerimeterValue = 40;

            Assert.Equal(expectedPerimeterValue, funcSquarePerimeter(10));
        }


        [Fact]
        public void GivenFuncWithOneIntInputParamAndOneDoubleOutParam_WhenCalculateCircleArea_ThenReturnCorrectValue()
        {
            Func<int, double> funcCircleArea = Circle.GetCircleArea;
            var expectedAreaValue = 706.8583470577034;

            Assert.Equal(expectedAreaValue, funcCircleArea(15));
        }

        [Fact]
        public void GivenFuncWithTwoIntInputParamAndOneDoubleOutParam_WhenCalculateRectangleArea_ThenReturnCorrectValue()
        {
            Func<int, int, double> funcRectangleArea = Rectangle.GetRectangleArea;
            var expectedAreaValue = 375;

            Assert.Equal(expectedAreaValue, funcRectangleArea(15, 25));
        }

        [Fact]
        public void GivenFuncWithTwoIntInputParamAndOneDoubleOutParam_WhenCalculateRectanglePerimeter_ThenReturnCorrectValue()
        {
            Func<int, int, double> funcRectanglePerimeter = Rectangle.GetRectanglePerimeter;
            var expectedPerimeterValue = 80;

            Assert.Equal(expectedPerimeterValue, funcRectanglePerimeter(15, 25));
        }

        [Fact]
        public void GivenFuncWithOneIntInputParamAndOneDoubleOutParam_WhenCalculateSquareAreaWithAnonymousMethod_ThenReturnCorrectValue()
        {
            Func<int, int> funcAnonymousMethodCalcSquareArea = delegate (int x) { return x * x; };
            var expectedAreaValue = 100;

            Assert.Equal(expectedAreaValue, funcAnonymousMethodCalcSquareArea(10));
        }

        [Fact]
        public void GivenFuncWithOneIntInputParamAndOneDoubleOutParam_WhenCalculateSquarePerimeterWithLambdaExpression_ThenReturnCorrectValue()
        {
            Func<int, int> funcLambdaExpCalcPerimeterArea = (int x) => 4 * x; 
            var expectedPerimeterValue = 40;

            Assert.Equal(expectedPerimeterValue, funcLambdaExpCalcPerimeterArea(10));
        }

    }
}