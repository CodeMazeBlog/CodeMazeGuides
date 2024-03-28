using BenchmarkAcrossDifferentDotNETVersions;

namespace Tests;

public class GetBooksTest
{
    [Fact]
    public void WhenGetBooksIsCalled_ThenReturnsAllBooks()
    {
        var books = BookService.GetBooks();

        Assert.IsType<List<Book>>(books);
        Assert.Equal(3, books.Count);
        Assert.Equal("Measuring Time", books[0].Title);
        Assert.Equal("Americanah", books[1].Title);
        Assert.Equal("Things Fall Apart", books[2].Title);
    }
}