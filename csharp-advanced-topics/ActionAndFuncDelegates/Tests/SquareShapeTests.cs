using ActionAndFuncDelegates;
using ActionAndFuncDelegates.Entities;
using Moq;

namespace Tests
{
    [TestClass]
	public class SquareShapeTests
    {
		private SquareShape _shape;
	    private Mock<SquareShape> _actionMock;

		[TestInitialize]
		public void Setup()
		{
			_actionMock = new Mock<SquareShape>();
            _shape = _actionMock.Object;
        }

		[TestMethod]
		public void GivenSide_WhenAreaOfSquareCalled_ThenAreaShouldBePrinted()
		{
			// Arrange
			_actionMock.Setup(x => x.Area(It.IsAny<Square>()));
            Action<Square> action = _shape.Area;
            
			// Act
            action.Invoke(new Square { Side = 4 });

            // Assert
            _actionMock.Verify(x => x.Area(It.IsAny<Square>()), Times.Once);
        }
	}
}
