using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncDelegatesInCsharp
{
	public static class CalculatorActivity
	{
		public static double SumActivity(double x, double y) => x + y;

		public static double SubtractActivity(double x, double y) => x - y;

		public static double MultiplyActivity(double x, double y) => x * y;

		public static double DivideActivity(double x, double y) => x / y;
	}
}