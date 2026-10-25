using System.Collections;

namespace IEnumerableCSharp;

public class GenericLibrary : IEnumerable<Book>
{
    private readonly Book[] _books;

    public GenericLibrary(Book[] books)
    {
        _books = [.. books];
    }

    public IEnumerator<Book> GetEnumerator()
    {
        foreach (var book in _books)
        {
            yield return book;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
