using HashSetvsSortedSetInCSharp;

namespace HashSetvsSortedSetInCSharpTests;

[TestClass]
public class SetOrderExamplesUnitTests
{
    [TestMethod]
    public void GivenASortedSet_WhenRemovingAndAdding_ThenElementsStayInAscendingOrder()
    {
        var lines = CaptureOutput(SetOrderExamples.PrintHashSetAndSortedSetOrder);

        Assert.AreEqual("1, 3, 4, 5, 6", lines[1]);
    }

    [TestMethod]
    public void GivenAHashSet_WhenRemovingAndAdding_ThenTheSameElementsComeBack()
    {
        var lines = CaptureOutput(SetOrderExamples.PrintHashSetAndSortedSetOrder);
        var elements = lines[0].Split(", ").Select(int.Parse).ToList();

        CollectionAssert.AreEquivalent(new List<int> { 1, 3, 4, 5, 6 }, elements);
    }

    [TestMethod]
    public void GivenAnOrderedDictionary_WhenAddingDuplicateKeys_ThenKeysKeepInsertionOrder()
    {
        OrderedDictionary<string, bool>? visited = null;
        var lines = CaptureOutput(() => visited = SetOrderExamples.TrackPagesInVisitOrder());

        Assert.AreEqual("home, pricing, docs", lines[0]);
        CollectionAssert.AreEqual(new List<string> { "home", "pricing", "docs" }, visited!.Keys.ToList());
    }

    [TestMethod]
    public void GivenASortedSetWithAYearComparer_WhenTwoBooksShareAYear_ThenTheSecondIsDropped()
    {
        SortedSet<Book>? books = null;
        var lines = CaptureOutput(() => books = SetOrderExamples.SortBooksByYear());

        Assert.AreEqual("2", lines[0]);
        Assert.AreEqual(2, books!.Count);
        Assert.IsFalse(books.Any(book => book.Title == "Flowers for Algernon"));
    }

    [TestMethod]
    public void GivenAHashSet_WhenTwoBooksShareAYear_ThenBothAreKept()
    {
        var books = SetOrderExamples.BooksInHashSet();

        Assert.AreEqual(3, books.Count);
    }

    private static string[] CaptureOutput(Action action)
    {
        var originalOut = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);

        try
        {
            action();
        }
        finally
        {
            Console.SetOut(originalOut);
        }

        return writer.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
    }
}
