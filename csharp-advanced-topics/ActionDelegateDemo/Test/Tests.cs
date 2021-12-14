using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
		delegate int CalDelegate(int num1, int num2);

		private int TwoSubsNo;
		public static int Addition(int num1, int num2)
		{
			return num1 + num2;
		}

		public void Subtraction(int num1, int num2)
		{
			TwoSubsNo = num1 - num2;
		}

		/// <summary>
		/// Test Delegate
		/// </summary>
		[TestMethod]
		public void WhenInputParameterIssent_DelegateExecutesTheReferencedMethod()
		{
			int num1 = 20, num2 = 10;

			var caldelegate = new CalDelegate(Addition);
			var result = caldelegate(num1,num2);
			Assert.AreEqual(Addition(num1,num2), result);
		}

		/// <summary>
		/// Function Delegate Test
		/// </summary>
		[TestMethod]
		public void whenInputparameterIsSent_FuncDelegateReturnsAdditionValue()
		{
			int num1 = 50, num2 = 10;

			Func<int, int, int> funcDelgate = new Func<int, int, int>(Addition);
			int result = funcDelgate.Invoke(num1, num2);
			Assert.AreEqual(Addition(num1, num2), result);
		}


		/// <summary>
		/// Action Delegate Test
		/// </summary>
		[TestMethod]
		public void whenInputParameterIsSent_ActionDelegateExecuteReferenceMethod()
		{
			int num1 = 50, num2 = 10;

			Action<int, int> actionDelgate = new Action<int, int>(Subtraction);
			actionDelgate.Invoke(num1, num2);
			Assert.AreEqual(TwoSubsNo, num1-num2);
		}


	}
}
