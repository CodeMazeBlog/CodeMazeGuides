using ActionAndFuncDelegates;
using ActionAndFuncDelegates.Entities;
using Moq;

namespace Tests
{
    [TestClass]
	public class RectangleShapeTests
    {
        private RectangleShape _shape;
        private Mock<RectangleShape> _funcMock;

        [TestInitialize]
        public void Setup()
        {
            _funcMock = new Mock<RectangleShape>();
            _shape = _funcMock.Object;
        }
        [TestMethod]
		public void GivenSides_WhenAreaOfRectangleCalled_ThenAreaShouldBeReturned()
		{
            // Arrange

            _funcMock.Setup(x => x.Area(It.IsAny<Rectangle>())).Returns(12);

            Func<Rectangle, int> func = _shape.Area;

			// Act
			var result = func.Invoke(new Rectangle 
			{ 
				Length = 10,
				Breadth = 5,
			});

			// Assert

			Assert.AreEqual(12, result);
            _funcMock.Verify(x => x.Area(It.IsAny<Rectangle>()), Times.Once);
        }
	}
}
