using System.Collections;

namespace IEnumerableCSharp;

public class Library : IEnumerable
{
    private readonly Book[] _books;

    public Library(Book[] books)
    {
        _books = [.. books];
    }

    public BookEnumerator GetEnumerator() => new BookEnumerator(_books);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
