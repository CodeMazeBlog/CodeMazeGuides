using VirtualMethodsInCSharp;
using Moq;

namespace Tests
{
    [TestClass]
    public class VirtualMethodsInCSharpUnitTests
    {
        [TestMethod]
        public void WhenShapeClassCalculateArea_ThenResultZero()
        {
            var shape = new Shape();
            var shapeArea = shape.CalculateArea();

            Assert.AreEqual(0, shapeArea);
        }

        [TestMethod]
        public void WhenRectangleClassCalculateArea_ThenRectangleClassCalculateAreaResult()
        {
            var rectangle = new Rectangle() { Height = 2, Width = 3 };
            var rectangleArea = rectangle.CalculateArea();

            Assert.AreEqual(6, rectangleArea);
        }

        [TestMethod]
        public void WhenCircleClassCalculateArea_ThenCircleClassCalculateAreaResult()
        {
            var circle = new Circle() { Radius = 2 };
            var circleArea = circle.CalculateArea();

            Assert.AreEqual(12.566370614359172, circleArea);
        }

        [TestMethod]
        public void WhenShapeClassGetShapeType_ThenShapeClassGetShapeTypeResult()
        {
            var shape = new Shape();
            var shapeType = shape.GetShapeType();

            Assert.AreEqual("This is a generic shape", shapeType);
        }

        [TestMethod]
        public void WhenRectangleClassGetShapeType_ThenRectangleClassGetShapeTypeResult()
        {
            var rectangle = new Rectangle() { Height = 2, Width = 3 };
            var rectangleType = rectangle.GetShapeType();

            Assert.AreEqual("This is a rectangle", rectangleType);
        }

        [TestMethod]
        public void WhenCircleClassGetShapeType_ThenShapeClassGetShapeTypeResult()
        {
            var circle = new Circle() { Radius = 2 };
            var circleType = circle.GetShapeType();

            Assert.AreEqual("This is a generic shape", circleType);
        }

        [TestMethod]
        public void WhenShapeClassDraw_ThenDrawingGenericShape()
        {
            var shape = new Shape();
            var shapeArea = shape.Draw();

            Assert.AreEqual("Drawing a generic shape", shapeArea);
        }

        [TestMethod]
        public void WhenRectangleClassDraw_ThenDrawingRectangle()
        {
            var rectangle = new Rectangle() { Height = 2, Width = 3 };
            var rectangleArea = rectangle.Draw();

            Assert.AreEqual("Drawing a rectangle", rectangleArea);
        }

        [TestMethod]
        public void WhenCircleClassDraw_ThenDrawingCircle()
        {
            var circle = new Circle() { Radius = 2 };
            var circleArea = circle.Draw();

            Assert.AreEqual("Drawing a circle", circleArea);
        }

        [TestMethod]
        public void WhenCircleClassGetShapeTypeMock_ThenCircleClassGetShapeTypeResult()
        {
            var circleMock = new Mock<Circle>();
            circleMock.Setup(p => p.GetShapeType()).Returns("This is a circle");
            var circleType = circleMock.Object.GetShapeType();

            Assert.AreEqual("This is a circle", circleType);
        }
    }
}