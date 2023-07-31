using ActionsAndFuncDelegatesInCsharp;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class CalculatorUnitTests
	{
		[Fact]
		public void GivenAnActivity_WhenPerformOperation_ThenPerformsOperationAndSendsResult()
		{
			var x = 10;
			var y = 20;
			var result = x + y;
			var email = "some-email@address.com";

			var mockedSending = new Mock<Action<double, string>>();
			var mockedActivity = new Mock<Func<double, double, double>>();
			mockedActivity.Setup(setup => setup.Invoke(x, y)).Returns(result);
			mockedSending.Setup(setup => setup.Invoke(result, email)).Verifiable();

			Calculator.PerformOperation(x, y, email, mockedActivity.Object, mockedSending.Object);

			mockedSending.Verify();
		}
	}
}
