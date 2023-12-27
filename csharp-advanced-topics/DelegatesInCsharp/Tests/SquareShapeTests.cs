using ActionAndFuncDelegate;
using ActionAndFuncDelegate.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
	public class SquareShapeTests
    {

		[TestMethod]
		public void GivenSide_WhenAreaOfSquareCalled_ThenAreaShouldBePrinted()
		{
			// Arrange

			var squareShape = new SquareShape();
			Action<Square> action = squareShape.Area;

			// Act
			action.Invoke(new Square 
			{ 
				Side = 2 
			});

			// Assert
		}
	}
}
