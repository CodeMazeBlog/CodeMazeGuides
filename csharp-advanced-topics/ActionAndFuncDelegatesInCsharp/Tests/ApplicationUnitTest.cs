using System;
using System.Collections.Generic;
using System.Text;
using ActionAndFuncDelegatesInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class ApplicationUnitTest
	{
		private Application _application;

		[TestMethod]
		public void WhenTwoIsAddedToFive_ThenResultShouldBeSevenForActionCalculatorUsingMethod()
		{
			_application = new Application(2, 5);
			_application.ActionCalculatorUsingMethod();

			var actual = _application.Result;

			var expected = 7;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void WhenTwoIsAddedToFive_ThenResultShouldBeSevenForActionCalculatorUsingAnonymousMethod()
		{
			_application = new Application(2, 5);
			_application.ActionCalculatorUsingAnonymousMethod();

			var actual = _application.Result;

			var expected = 7;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void WhenTwoIsAddedToFive_ThenResultShouldBeSevenForFuncCalculatorUsingMethod()
		{
			_application = new Application(2, 5);
			_application.FuncCalculatorUsingMethod();

			var actual = _application.Result;

			var expected = 7;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void WhenTwoIsAddedToFive_ThenResultShouldBeSevenForFuncCalculatorUsingAnonymousMethod()
		{
			_application = new Application(2, 5);
			_application.FuncCalculatorUsingAnonymousMethod();

			var actual = _application.Result;

			var expected = 7;
			Assert.AreEqual(expected, actual);
		}
	}
}
