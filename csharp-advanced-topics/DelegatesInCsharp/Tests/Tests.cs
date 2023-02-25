using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace Tests
{
	delegate string PrintMessage(string text);
	delegate T Print<T>(T param1);

	[TestClass]
	public class Tests
	{
        Action<string> printUpperCase = (s) => Console.WriteLine(s.ToUpper());
        Action<string> printLowerCase = (s) => Console.WriteLine(s.ToLower());
        Action<string> printCapitzalizeCase = (s) => Console.WriteLine(Regex.Replace(s, @"((^\w)|(\s|\p{P})\w)",
                                        match => match.Value.ToUpper()));

        Func<int, int, int> add = (x, y) => x + y;
        Func<int, int, int> sub = (x, y) => x - y;
        Func<int, int, int> mult = (x, y) => x * y;
        Func<int, int, int> div = (x, y) => x / y;



        [TestMethod]
		public void whenActionDelegate_DelegateInvocationListNotEmpty()
		{			
			var invocationList = printUpperCase.GetInvocationList();
			Assert.AreEqual(invocationList.Length, 1);
		}

		[TestMethod]
		public void whenFuncDelegate_DelegateInvocationListNotEmpty()
		{
			var invocationList = add.GetInvocationList();
			Assert.AreEqual(invocationList.Length, 1);
		}
	}
}
