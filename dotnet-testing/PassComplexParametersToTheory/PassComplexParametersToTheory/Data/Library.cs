namespace PassComplexParametersToTheory.Data;

public class Library
{
    public List<Book> Books { get; set; } = [];
    public List<Author> Authors { get; set; } = [];

    public bool AddBook(Book book)
    {
        if (book is not null && !Books.Contains(book))
        {
            Books.Add(book);
            return true;
        }

        return false;
    }

    public bool AddAuthor(Author author)
    {
        if (author is not null && !Authors.Contains(author))
        {
            Authors.Add(author);
            return true;
        }

        return false;
    }
}
