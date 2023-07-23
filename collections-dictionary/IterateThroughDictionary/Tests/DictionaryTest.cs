using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IterateThroughDictionary;
using System.Collections.Generic;
using System.IO;

namespace DictionaryTests
{
	[TestClass]
	public class DictionaryTest
	{
		public static readonly string _monthJanuary = "1 : January";
		public static readonly string _monthFebruary = "2 : February";
		public static readonly string _monthMarch = "3 : March";
		public static readonly string _monthApril = "4 : April";
		public static readonly string _monthJanuaryStringJoin = "[1, January]";

		private StringWriter _stringWriter = new StringWriter();

		public DictionaryTest()
		{
			Console.SetOut(_stringWriter);
		}

		private static Dictionary<int, string> _months = new Dictionary<int, string>
		{
			{1,"January" },
			{2,"February" },
			{3,"March" },
			{4,"April" }
		 };

		[TestMethod]
		public void WhenDictionaryUsesForEach_ThenOutputsReqdResults()
		{
			Program.SubDictionaryUsingForEach(_months);

			var outputLines = _stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

			Assert.AreEqual(_monthJanuary, outputLines[0]);
			Assert.AreEqual(_monthFebruary, outputLines[1]);
			Assert.AreEqual(_monthMarch, outputLines[2]);
			Assert.AreEqual(_monthApril, outputLines[3]);
		}

		[TestMethod]
		public void WhenDictionaryUsesKeyValuePair_ThenOutputsReqdResults()
		{
			Program.SubDictionaryKeyValuePair(_months);

			var outputLines = _stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

			Assert.AreEqual(_monthJanuary, outputLines[0]);
			Assert.AreEqual(_monthFebruary, outputLines[1]);
			Assert.AreEqual(_monthMarch, outputLines[2]);
			Assert.AreEqual(_monthApril, outputLines[3]);
		}

		[TestMethod]
		public void WhenDictionaryUsesForLoop_ThenOutputsReqdResults()
		{
			Program.SubDictionaryForLoop(_months);

			var outputLines = _stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

			Assert.AreEqual(_monthJanuary, outputLines[0]);
			Assert.AreEqual(_monthFebruary, outputLines[1]);
			Assert.AreEqual(_monthMarch, outputLines[2]);
			Assert.AreEqual(_monthApril, outputLines[3]);
		}

		[TestMethod]
		public void WhenDictionaryUsesParallelEnumerable_ThenOutputsReqdResults()
		{
			Program.SubDictionaryParallelEnumerable(_months);

			var resultlines = _stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i <= resultlines.Length; i++)
			{
				if (resultlines[0].ToString() == _monthJanuary)
					Assert.AreEqual(_monthJanuary, resultlines[0]);
				if (resultlines[1].ToString() == _monthFebruary)
					Assert.AreEqual(_monthFebruary, resultlines[1]);
				if (resultlines[2].ToString() == _monthMarch)
					Assert.AreEqual(_monthMarch, resultlines[2]);
				if (resultlines[3].ToString() == _monthApril)
					Assert.AreEqual(_monthApril, resultlines[3]);
			}
		}
	}
}
