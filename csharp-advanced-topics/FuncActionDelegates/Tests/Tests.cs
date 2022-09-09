using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FuncActionDelegates;

namespace Tests
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void whenStringIsSent_ThenDelegateExecutesTheReferencedMethod()
		{
			var delegate1 = new PrintMessage(SampleFunctions.WriteText);
			var result = delegate1("You're gonna need a bigger boat.");
			Assert.AreEqual("Text:You're gonna need a bigger boat.", result);
		}

		[TestMethod]
		public void whenDelegateIsInvoked_ThenDelegateExecutesReferencedMethod()
		{
			var delegate2 = SampleFunctions.WriteText;
			var result = delegate2.Invoke("You're gonna need a bigger boat.");
			Assert.AreEqual("Text:You're gonna need a bigger boat.", result);
		}

		[TestMethod]
		public void whenDelegateIsInvoked_ThenDelegateExecutesAnonymousReferencedMethod()
		{
			var delegate3 = delegate (string text) { return $"Text:{text}"; };
			var result = delegate3.Invoke("You're gonna need a bigger boat.");
			Assert.AreEqual("Text:You're gonna need a bigger boat.", result);
		}

		[TestMethod]
		public void whenDelegateIsInvoked_ThenDelegateExecutesExpressionLambda()
		{
			PrintMessage delegate4 = text => { return $"Text:{text}"; };
			var result = delegate4("You're gonna need a bigger boat.");
			Assert.AreEqual("Text:You're gonna need a bigger boat.", result);
		}

		[TestMethod]
		public void whenFuncDelegate_ThenDelegateExecutesReferencedMethod()
		{
			Func<int, int, int> AddTwoNumbers = SampleFunctions.AddNumbers;
			int result = AddTwoNumbers(10, 20);
			Assert.AreEqual(30, result);
		}

		[TestMethod]
		public void whenFuncDelegate_ThenDelegateExecutesAnonymousFunction()
		{
			Func<int, int, int> AddTwoNumbers = delegate (int param1, int param2) { return param1 + param2; };
			int result = AddTwoNumbers(10, 20);
			Assert.AreEqual(30, result);
		}

		[TestMethod]
		public void whenFuncDelegate_ThenDelegateExecutesExpressionLambda()
		{
			Func<int, int, int> AddTwoNumbers = (param1, param2) => param1 + param2;
			int result = AddTwoNumbers(10, 20);
			Assert.AreEqual(30, result);
		}

		[TestMethod]
		public void whenActionDelegate_ThenDelegateExecutesReferencedMethod()
		{
			Action<int, int> Addition = SampleFunctions.AddTwoNumbers;
			Addition(10, 20);
			Assert.AreEqual(30, SampleFunctions.result);
		}

		[TestMethod]		
		public void whenActionDelegate_ThenDelegateExecutesAnonymousMethod()
		{
			Action<int, int> Addition1 = delegate (int param1, int param2) { SampleFunctions.result = param1 + param2; };
			Addition1(10, 20);
			Assert.AreEqual(30, SampleFunctions.result);
		}

		[TestMethod]
		
		public void whenActionDelegate_ThenDelegateExecutesExpressionLambda()
		{
			Action<int, int> Addition2 = (param1, param2) => SampleFunctions.result = param1 + param2;
			Addition2(10, 20);
			Assert.AreEqual(30, SampleFunctions.result);
		}
    }
}
