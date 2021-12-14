using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuncAndAction;
using System.Collections.Generic;

namespace Tests
{
	[TestClass]
	public class Tests
	{
		string[] names = { "Alice", "John", "Bobby", "Kyle", "Scott", "Tod", "Sharon", "Armin", "George" };
		Func<string, bool> lessThanFive = x => x.Length < 5;

		private static List<string> tempLessThanFive(string[] items) 
		{
			List<string> tempNamesLessThanFiveChars = new List<string>();

			foreach (var item in items)
            {
				if(item.Length < 5)
				{ 
				tempNamesLessThanFiveChars.Add(item);
				}
			}
			return tempNamesLessThanFiveChars;
		}

		[TestMethod]
		public void whenStringsAreSent_FuncExtractsStringWithLengthLessThanFiveChars()
		{
			List<string> namesLessThanFiveChars = EntryPoint.ExtractStrings(names,lessThanFive);
			Assert.AreEqual(tempLessThanFive(names).Count, namesLessThanFiveChars.Count);
		}

        [TestMethod]
        public void whenStringIsSent_ActionPrints()
        {
            EntryPoint.Print("Print Something");
			Assert.IsTrue(true);
        }

    }
}
