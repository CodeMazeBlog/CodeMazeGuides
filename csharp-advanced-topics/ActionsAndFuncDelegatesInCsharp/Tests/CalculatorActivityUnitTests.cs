using ActionsAndFuncDelegatesInCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class CalculatorActivityUnitTests
	{
		[Fact]
		public void GivenInputXandY_WhenSumActivity_ThenSumOfXandYShouldBeGotten()
		{
			var x = 5.2435;
			var y = 49;

			var result = CalculatorActivity.SumActivity(x, y);

			Assert.Equal(54.2435, result);
		}

		[Fact]
		public void GivenInputXandY_WhenSubtractActivity_ThenYShouldBeSubtractedFromX()
		{
			var x = 49;
			var y = 5;

			var result = CalculatorActivity.SubtractActivity(x, y);

			Assert.Equal(44, result);
		}

		[Fact]
		public void GivenInputXandY_WhenDivideActivity_ThenYShouldDivideX()
		{
			var x = 50;
			var y = 5;

			var result = CalculatorActivity.DivideActivity(x, y);

			Assert.Equal(10, result);
		}

		[Fact]
		public void GivenInputXandY_WhenMultiplyActivity_ThenXShouldMultiplyY()
		{
			var x = 50;
			var y = 5;

			var result = CalculatorActivity.MultiplyActivity(x, y);

			Assert.Equal(250, result);
		}
	}
}
