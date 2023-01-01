using FuncAndActionInCSharp.Shapes;

namespace FuncAndActionInCSharp.Tests
{
    public class ActionUnitTest
    {
        [Fact]
        public void GivenActionWithOneIntInputParam_WhenCalculateSquareArea_ThenPrintCorrectValue()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Action<int> actionSquareArea = Square.PrintSquareArea;

            actionSquareArea(10);
            var sb = writer.GetStringBuilder();
            var expectedAreaValue = "The area of a square of side 10 is: 100";

            Assert.Equal(expectedAreaValue, sb.ToString().TrimEnd());

        }
        
        [Fact]
        public void GivenActionWithOneIntInputParam_WhenCalculateSquarePerimeter_ThenPrintCorrectValue()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Action<int> actionSquarePerimeter = Square.PrintSquarePerimeter;

            actionSquarePerimeter(10);
            var sb = writer.GetStringBuilder();
            var expectedPerimeterValue = "The perimeter of a square of side 10 is: 40";

            Assert.Equal(expectedPerimeterValue, sb.ToString().TrimEnd());
        }


        [Fact]
        public void GivenActionWithOneIntInputParam_WhenCalculateCircleArea_ThenPrintCorrectValuee()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Action<int> actionCircleArea = Circle.PrintCircleArea;

            actionCircleArea(15);
            var sb = writer.GetStringBuilder();
            var expectedAreaValue = "The area of a circle with radius 15 is: 706.8583470577034";

            Assert.Equal(expectedAreaValue, sb.ToString().TrimEnd());
        }


        [Fact]
        public void GivenActionWithTwoIntInputParams_WhenCalculateRectangleArea_ThenPrintCorrectValue()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Action<int, int> actionRectangleArea = Shapes.Rectangle.PrintRectangleArea;

            actionRectangleArea(15, 25);
            var sb = writer.GetStringBuilder();
            var expectedAreaValue = "The area of a rectangle with length 15 and width 25 is: 375";

            Assert.Equal(expectedAreaValue, sb.ToString().TrimEnd());
        }

        [Fact]
        public void GivenActionWithTwoIntInputParams_WhenCalculateRectanglePerimeter_ThenPrintCorrectValue()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Action<int, int> actionRectanglePerimeter = Shapes.Rectangle.PrintRectanglePerimeter;

            actionRectanglePerimeter(15, 25);
            var sb = writer.GetStringBuilder();
            var expectedPerimeterValue = "The perimeter of a rectangle with length 15 and width 25 is: 80";

            Assert.Equal(expectedPerimeterValue, sb.ToString().TrimEnd());
        }

        [Fact]
        public void GivenActionWithOneIntInputParam_WhenCalculateSquareAreaWithAnonymousMethod_ThenPrintCorrectValue()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Action<int> actionAnonymousMethodCalcSquareArea = delegate (int x)
            {
                Console.WriteLine($"The area of a square of side {x} is: {x * x}");
            };

            actionAnonymousMethodCalcSquareArea(10);
            var sb = writer.GetStringBuilder();
            var expectedAreaValue = "The area of a square of side 10 is: 100";

            Assert.Equal(expectedAreaValue, sb.ToString().TrimEnd());
        }

        [Fact]
        public void GivenActionWithOneIntInputParam_WhenCalculateSquarePerimeterWithLambdaExpression_ThenPrintCorrectValue()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Action<int> actionLambdaExpCalcPerimeterArea = (int x) => Console.WriteLine($"The perimeter of a square of side {x} is: {4 * x}");

            actionLambdaExpCalcPerimeterArea(10);
            var sb = writer.GetStringBuilder();
            var expectedPerimeterValue = "The perimeter of a square of side 10 is: 40";

            Assert.Equal(expectedPerimeterValue, sb.ToString().TrimEnd());
        }

    }
}