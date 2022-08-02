using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
	delegate string PrintMessage(string text);
	delegate T Print<T>(T param1);

	[TestClass]
	public class Tests
	{
		public static string WriteText(string text) { return $"Text:{text}"; }
		public static string ReverseText(string text) { return Reverse(text); }
		public static void ReverseWriteText(string text) { Console.WriteLine(Reverse(text)); }

		private static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		[TestMethod]
		public void whenStringIsSent_DelegateExecutesTheReferencedMethod()
		{
			var delegate1 = new PrintMessage(WriteText);
			var result = delegate1("You're gonna need a bigger boat.");
			Assert.AreEqual("Text:You're gonna need a bigger boat.", result);
		}

		[TestMethod]
		public void whenStringIsSent_DelegateReturnsTheReversedString()
		{
			var delegate1 = new PrintMessage(ReverseText);
			var result = delegate1("You're gonna need a bigger boat.");
			Assert.AreEqual(Reverse("You're gonna need a bigger boat."), result);
		}

		[TestMethod]
		public void givenMulticastDelegate_whenTwoReferencedMethodAndPlusSign_DelegateInvocationListContainsTwoMethods()
		{
			var delegate1 = new PrintMessage(WriteText);
			var delegate2 = new PrintMessage(ReverseText);
			var multicastDelegate = delegate1 + delegate2;

			var invocationList = multicastDelegate.GetInvocationList();

			Assert.AreEqual(invocationList.Length, 2);
			Assert.AreEqual(invocationList[0].Method.Name, "WriteText");
			Assert.AreEqual(invocationList[1].Method.Name, "ReverseText");
		}

		[TestMethod]
		public void givenMulticastDelegate_whenTwoReferencedMethodAndPlusEquals_DelegateInvocationListContainsTwoMethods()
		{
			var delegate1 = new PrintMessage(WriteText);
			var delegate2 = new PrintMessage(ReverseText);
			var multicastDelegate = delegate1;
			multicastDelegate += delegate2;

			var invocationList = multicastDelegate.GetInvocationList();

			Assert.AreEqual(invocationList.Length, 2);
			Assert.AreEqual(invocationList[0].Method.Name, "WriteText");
			Assert.AreEqual(invocationList[1].Method.Name, "ReverseText");
		}

		[TestMethod]
		public void whenGenericDelegate_DelegateExecutesTheReferencedMethod()
		{
			var delegate1 = new Print<string>(ReverseText);
			
			var result = delegate1("You're gonna need a bigger boat.");

			Assert.AreEqual(Reverse("You're gonna need a bigger boat."), result);
		}

		[TestMethod]
		public void whenActionDelegate_DelegateInvocationListNotEmpty()
		{
			Action<string> executeReverseWriteAction = ReverseWriteText;
			var invocationList = executeReverseWriteAction.GetInvocationList();
			Assert.AreEqual(invocationList.Length, 1);
		}

		[TestMethod]
		public void whenFuncDelegate_DelegateInvocationListNotEmpty()
		{
			Func<string, string> executeReverseWriteAction = ReverseText;
			var invocationList = executeReverseWriteAction.GetInvocationList();
			Assert.AreEqual(invocationList.Length, 1);
		}
	}
}
