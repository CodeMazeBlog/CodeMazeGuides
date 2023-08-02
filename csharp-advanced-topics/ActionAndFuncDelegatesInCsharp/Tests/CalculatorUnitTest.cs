using ActionAndFuncDelegatesInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
	[TestClass]
	public class CalculatorUnitTest
	{
		private Calculator _calculator;
		public CalculatorUnitTest()
		{
			_calculator = new Calculator();
		}
		[TestMethod]
		public void WhenTwoIsAddedToFive_ThenResultShouldBeSevenForAddUsingAction()
		{
			_calculator.AddUsingAction(2, 5);

			var actual = _calculator.Result;

			var expected = 7;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void WhenTwoIsAddedToFive_ThenResultShouldBeSevenForAddUsingFunc()
		{
			var actual = _calculator.AddUsingFunc(2, 5);
			
			var expected = 7;
			Assert.AreEqual(expected, actual);
		}
	}
}
