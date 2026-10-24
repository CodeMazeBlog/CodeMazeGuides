using System.Collections;
using IEnumerableCSharp;

namespace Tests;

public class LibraryTests
{
    private static readonly Book[] Books =
    [
        new("Anna Karenina", "Leo Tolstoy"),
        new("To Kill a Mockingbird", "Harper Lee"),
        new("War and Peace", "Leo Tolstoy")
    ];

    [Fact]
    public void WhenIteratingLibrary_ThenEveryBookComesBackInOrder()
    {
        var names = new List<string>();

        foreach (var book in new Library(Books))
        {
            names.Add(book.Name);
        }

        Assert.Equal(["Anna Karenina", "To Kill a Mockingbird", "War and Peace"], names);
    }

    [Fact]
    public void WhenUsingLinqOnNonGenericLibrary_ThenCastIsNeeded()
    {
        var tolstoy = new Library(Books).Cast<Book>().Where(book => book.Author == "Leo Tolstoy");

        Assert.Equal(2, tolstoy.Count());
    }

    [Fact]
    public void WhenUsingLinqOnGenericLibrary_ThenNoCastIsNeeded()
    {
        var tolstoy = new GenericLibrary(Books).Where(book => book.Author == "Leo Tolstoy");

        Assert.Equal(2, tolstoy.Count());
    }

    [Fact]
    public void WhenResettingIteratorEnumerator_ThenNotSupportedExceptionIsThrown()
    {
        using var enumerator = new GenericLibrary(Books).GetEnumerator();

        Assert.Throws<NotSupportedException>(() => enumerator.Reset());
    }
}
