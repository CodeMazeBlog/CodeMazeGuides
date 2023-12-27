using ActionAndFuncDelegates;
using ActionAndFuncDelegates.Entities;

namespace Tests
{
    [TestClass]
	public class RectangleShapeTests
    {

		[TestMethod]
		public void GivenSides_WhenAreaOfRectangleCalled_ThenAreaShouldBeReturned()
		{
			// Arrange

			var rectangleShape = new RectangleShape();
			Func<Rectangle, int> func = rectangleShape.Area;

			// Act
			var result = func.Invoke(new Rectangle 
			{ 
				Length = 10,
				Breadth = 5,
			});

			// Assert

			Assert.AreEqual(50, result);
		}
	}
}
