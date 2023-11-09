using HowToUseShouldly;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

namespace Tests;

[TestClass]
public class BookUnitTest
{
    [TestMethod]
    public void GivenABook_WhenANewEditionIsPublished_ThenEditionIsIncreased()
    {
        var book = new Book("title", "text", new[] { "author1" });
        var oldEdition = book.NumEditions;

        book.PublishNewEdition();

        // Assert.AreEqual(oldEdition + 1, book.NumEditions);
        book.NumEditions.ShouldBe(oldEdition + 1);
    }

    [TestMethod]
    public void GivenABook_WhenAnAuthorIsAdded_ThenItIsIncludedInAuthors()
    {
        var book = new Book("title", "text", new[] { "author1" });

        book.AddAuthor("author2");

        // CollectionAssert.Contains(book.Authors.ToList(), "author2");
        book.Authors.ShouldContain("author2");
    }

    [TestMethod]
    public void GivenABook_WhenThereIsDuplicatedAuthor_ThenThrowArgumentException()
    {
        var book = new Book("title", "text", new[] { "author1" });

        // Assert.ThrowsException<ArgumentException>(() => book.AddAuthor("author1"));
        Should.Throw<ArgumentException>(() => book.AddAuthor("author1"));
    }

    [TestMethod]
    public void GivenABook_WhenAskForBow_ThenReturnBow()
    {
        var book = new Book("title", "word1 word2 word1", new[] { "author1" });

        // soft assertions do not exists in MSTest
        book.GetBagOfWords()
            .ShouldSatisfyAllConditions(
                bow => bow.ShouldContainKeyAndValue("word1", 2),
                bow => bow.ShouldContainKeyAndValue("word2", 1)
            );
    }

    [TestMethod]
    public void GivenABook_WhenAddNewChapter_ThenChapterIsAppended()
    {
        var book = new Book("title", "text", new[] { "author1" });

        book.AddChapter("new chapter");

        // StringAssert.EndsWith(book.Text, "new chapter");
        book.Text.ShouldEndWith("new chapter");
    }

    [TestMethod]
    public void GivenABook_WhenAskForBow_ThenCompletesWithin5Seconds()
    {
        var book = new Book("title", "text", new[] { "author1" });

        Should.CompleteIn(
            () =>
            {
                book.GetBagOfWords();
            },
            TimeSpan.FromSeconds(5)
        );
    }
}
