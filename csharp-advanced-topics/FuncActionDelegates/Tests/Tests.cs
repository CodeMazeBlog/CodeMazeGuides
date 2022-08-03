using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
	//Example for Declaring a delegate
	delegate string PrintMessage(string text);

	[TestClass]
	public class Tests
	{
		//----------------------------- Secondary functions and variables to run the examples -----------------------------------
		public static int result3;
		public static int result4;
		public static int result5;

		public static string WriteText1(string text) { return $"Text:{text}"; }
		public static int AddNumbers(int param1, int param2) { return param1 + param2; }
		public static void AddTwoNumbers3(int param1, int param2) { result3 = param1 + param2; }
		

		//------------------------------------------ Using delegates Tests -----------------------------------------------

		[TestMethod]
		public void Delegate_InstatiateGeneralCase()
		{
			//Example1 to instantiate the delegate
			var delegate1 = new PrintMessage(WriteText1);
			//Invoking the delegate
			var result = delegate1("You're gonna need a bigger boat.");
			//Validating the test result
			Assert.AreEqual("Text:You're gonna need a bigger boat.", result);
		}

		[TestMethod]
		public void Delegate_InstatiateSimplifiedExpression()
		{
			//Example2 now let's simplify the expression to instantiate the delegate
			var delegate2 = WriteText1;
			//Invoking the delegate with the keyword "Invoke"
			var result = delegate2.Invoke("You're gonna need a bigger boat.");
			//Validating the test result
			Assert.AreEqual("Text:You're gonna need a bigger boat.", result);
		}

		[TestMethod]
		public void Delegate_InstatiateAnonymousMethod()
		{
			//Example3 now we use an Anonymous method to instantiate the delegate
			var delegate3 = delegate (string text) { return $"Text:{text}"; };
			//Invoking the delegate with the keyword "Invoke"
			var result = delegate3.Invoke("You're gonna need a bigger boat.");
			//Validating the test result
			Assert.AreEqual("Text:You're gonna need a bigger boat.", result);
		}

		[TestMethod]
		public void Delegate_InstatiateLambdaExpression()
		{
			//Example4 it is possible to use a Lambda Expression to instantiate the delegate
			PrintMessage delegate4 = text => { return $"Text:{text}"; };
			//Invoking the delegate with ()
			var result = delegate4("You're gonna need a bigger boat.");
			//Validating the test result
			Assert.AreEqual("Text:You're gonna need a bigger boat.", result);
		}

		//------------------------------------------ Func Delegate Tests -------------------------------------------------

		[TestMethod]
		public void FuncDelegate_GeneralCase()
		{
			//Example1 using Func delegate
			Func<int, int, int> AddTwoNumbers = AddNumbers;
			int result = AddTwoNumbers(10, 20);
			//Validating the test result
			Assert.AreEqual(30, result);
		}

		[TestMethod]
		public void FuncDelegate_AnonymousMethod()
		{
			//Example2 Func delegate with an Anonymous Method
			Func<int, int, int> AddTwoNumbers = delegate (int param1, int param2) { return param1 + param2; };
			int result = AddTwoNumbers(10, 20);
			//Validating the test result
			Assert.AreEqual(30, result);
		}

		[TestMethod]
		public void FuncDelegate_LambdaExpression()
		{
			//Example3 Func delegate with Lambda Expression
			Func<int, int, int> AddTwoNumbers = (param1, param2) => param1 + param2;
			int result = AddTwoNumbers(10, 20);
			//Validating the test result
			Assert.AreEqual(30, result);
		}

		//------------------------------------------ Action Delegate Tests -----------------------------------------------

		[TestMethod]
		public void ActionDelegate_GeneralCase()
		{
			//Example1 Action delegate is the method "AddTwoNumbers3" that takes 2 parameters but returns nothing
			Action<int, int> Addition = AddTwoNumbers3;
			Addition(10, 20);
			//Validating the test result
			Assert.AreEqual(30, result3);
		}

		[TestMethod]
		public void ActionDelegate_AnonymousMethod()
		{
			//Example2 Action delegate with an Anonymous method
			Action<int, int> Addition1 = delegate (int param1, int param2) { result4 = param1 + param2; };
			Addition1(10, 20);
			//Validating the test result
			Assert.AreEqual(30, result4);
		}

		[TestMethod]
		public void ActionDelegate_LambdaExpression()
		{
			//Example3 Action delegate can use a Lambda expression
			Action<int, int> Addition2 = (param1, param2) => result5 = param1 + param2;
			Addition2(10, 20);
			//Validating the test result
			Assert.AreEqual(30, result5);
		}
    }
}
