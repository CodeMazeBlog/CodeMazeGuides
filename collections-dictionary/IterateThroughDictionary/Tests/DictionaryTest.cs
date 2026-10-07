using Microsoft.VisualStudio.TestTools.UnitTesting;
using IterateThroughDictionary;

namespace DictionaryTests;

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
	public void WhenDictionaryUsesKeys_ThenOutputsEveryKey()
	{
		Program.SubDictionaryUsingKeys(_months);

		var outputLines = _stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

		CollectionAssert.AreEqual(new[] { "1", "2", "3", "4" }, outputLines);
	}

	[TestMethod]
	public void WhenDictionaryUsesValues_ThenOutputsEveryValue()
	{
		Program.SubDictionaryUsingValues(_months);

		var outputLines = _stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

		CollectionAssert.AreEqual(new[] { "January", "February", "March", "April" }, outputLines);
	}

	[TestMethod]
	public void WhenDictionaryRemovesWhileIterating_ThenOnlyMatchingEntriesAreRemoved()
	{
		var months = new Dictionary<int, string>(_months);

		Program.SubDictionaryRemoveWhileIterating(months);

		CollectionAssert.AreEquivalent(new[] { 2, 3, 4 }, months.Keys.ToArray());
		CollectionAssert.AreEquivalent(new[] { "February", "March", "April" }, months.Values.ToArray());
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

		CollectionAssert.AreEquivalent(new[] { _monthJanuary, _monthFebruary, _monthMarch, _monthApril }, resultlines);
	}
}
