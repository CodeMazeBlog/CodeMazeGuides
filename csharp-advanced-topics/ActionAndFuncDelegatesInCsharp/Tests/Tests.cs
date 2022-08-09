using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tests
{
	[TestClass]
	public class Tests
	{
		StringWriter stringWriter = new StringWriter();
		
		static void ConsolePrint(int i)
		{
			Console.WriteLine(i);
		}
		
		static int Add(int x, int y)
		{
			return x + y;
		}

		[TestMethod]
		public void WhenRegularDelegate_ThenPrintInt()
		{
			Console.SetOut(stringWriter);
			var printRegularDelegate = ConsolePrint;
			printRegularDelegate(10);
			Assert.AreEqual("10", stringWriter.ToString());
		}

		[TestMethod]
		public void WhenActionDelegate_ThenPrintInt()
		{
			Console.SetOut(stringWriter);
			Action<int> printActionDelegate = ConsolePrint;
			printActionDelegate(10);
			Assert.AreEqual("10", stringWriter.ToString());
		}
		
		[TestMethod]
		public void WhenActionDelegateWithAnonymous_ThenPrintInt()
		{
			Console.SetOut(stringWriter);
			Action<int> printActionDelegateAnonymous = delegate(int i) { Console.WriteLine(i); };
			printActionDelegateAnonymous(10);
			Assert.AreEqual("10", stringWriter.ToString());
		}
		
		[TestMethod]
		public void WhenActionDelegateWithLambda_ThenPrintInt()
		{
			Console.SetOut(stringWriter);
			Action<int> printActionDelegateLambda = i => Console.WriteLine(i);
			printActionDelegateLambda(10);
			Assert.AreEqual("10", stringWriter.ToString());
		}
		
		[TestMethod]
		public void WhenRegularDelegate_ThenAddInts()
		{
			var addRegularDelegate = Add;
			var result = addRegularDelegate(6, 4);
			Assert.AreEqual(result, 10);
		}

		[TestMethod]
		public void WhenFuncDelegate_ThenAddInts()
		{
			Func<int, int, int> addFuncDelegate = Add;
			var result = addFuncDelegate(6, 4);
			Assert.AreEqual(result, 10);
		}
		
		[TestMethod]
		public void WhenFuncDelegateWithAnonymous_ThenAddInts()
		{
			Func<int, int, int> addFuncDelegateAnonymous = delegate(int x, int y) { return x + y; };
			var result = addFuncDelegateAnonymous(6, 4);
			Assert.AreEqual(result, 10);
		}
		
		[TestMethod]
		public void WhenFuncDelegateWithLambda_ThenAddInts()
		{
			Func<int, int, int> addFuncDelegateLambda = (x, y) => x + y;
			var result = addFuncDelegateLambda(6, 4);
			Assert.AreEqual(result, 10);
		}
	}
}