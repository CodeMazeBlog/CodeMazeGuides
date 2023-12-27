using ActionAndFuncDelegate;
using ActionAndFuncDelegate.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
