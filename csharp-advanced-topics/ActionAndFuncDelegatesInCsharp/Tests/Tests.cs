using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using ActionAndFuncDelegatesInCsharp;
using System.Text;
using System.IO;

namespace Tests
{
	[TestClass]
	public class Tests
	{
		StringWriter stringWriter = new StringWriter();
		List<string> names = new List<string> { "bill", "bob", "merry", "jack", "fergus", "sam" };
		string CraftException(string message) => @$"New System.Exception
			=================================
			Time           | {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}
			Message        | {message}
			Stack Trace    | 

		".Replace("\t", ""); // We put in the tabs for neater formatting, and remove it programmatically.

		public Tests()
		{
			//arrange
			Console.SetOut(stringWriter);
		}

		[TestMethod]
		public void whenFireDelegateExceptionIsCalled_ThenMethodPrintsCorrectExceptionMessage()
		{
			//arrange
			Program.names = names;
			string expected = CraftException("Houston, we have a problem");

			//act
			Program.FireDelegateException();

			//assert
			var output = stringWriter.ToString();
			Assert.AreEqual(expected, output);
		}

		[TestMethod]
		public void whenFireActionExceptionIsCalled_ThenMethodPrintsCorrectExceptionMessage()
		{
			//arrange
			Program.names = names;
			string expected = CraftException("Houston, we have a problem");

			//act
			Program.FireActionException();

			//assert
			var output = stringWriter.ToString();
			Assert.AreEqual(expected, output);
		}

		[TestMethod]
		public void whenPrintAllNamesIsCalled_ThenMethodPrintsCorrectNamesList()
		{
			//arrange
			Program.names = names;
			string expected = String.Join("", names);

			//act
			Program.PrintAllNames();

			//assert
			var output = stringWriter.ToString().Replace(Environment.NewLine,"");
			Assert.IsTrue(expected == output);
		}

		[TestMethod]
		public void whenPrintFiveLetterNamesIsCalled_ThenMethodPrintsCorrectNamesList()
		{
			//arrange
			Program.names = names;
			string expected = String.Join("", names.Where(n => n.Length == 5));

			//act
			Program.PrintFiveLetterNames();

			//assert
			var output = stringWriter.ToString().Replace(Environment.NewLine, "");
			Assert.IsTrue(expected == output);
		}

		[TestMethod]
		public void whenLogErrorIsCalled_ThenMethodPrintsCorrectExceptionMessage()
		{
			//arrange
			var testException = new Exception("You shall not pass!");
			string expected = CraftException("You shall not pass!");

			//act
			Program.LogError(testException);

			//assert
			var output = stringWriter.ToString();
			Assert.AreEqual(expected, output);
		}
	}
}
