using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncDelegatesInCsharp
{
	public static class Calculator
	{
		public static void PerformOperation(
			double x,
			double y,
			string sendOption,
			Func<double, double, double> calculatorActivity,
			Action<double, string> sendAction)
		{
			var operationResult = calculatorActivity(x, y);

			sendAction(operationResult, sendOption);
		}
	}
}
