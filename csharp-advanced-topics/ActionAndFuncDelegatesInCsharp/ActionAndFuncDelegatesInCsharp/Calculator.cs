using System;
using System.Collections.Generic;
using System.Text;

namespace ActionAndFuncDelegatesInCsharp
{
	public class Calculator
	{
		public int Result { get; private set; }

		public void AddUsingAction(int num1, int num2)
		{
			Result = num1 + num2;
		}
		public int AddUsingFunc(int num1, int num2)
		{
			return num1 + num2;
		}
	}
}
