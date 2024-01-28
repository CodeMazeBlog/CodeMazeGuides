using PassComplexParametersToTheory.Data;

namespace PassComplexParametersToTheory.Services;

public class LibraryService(Library library) : ILibraryService
{
    public bool CheckOutBook(int bookId)
    {
        var book = library.Books.Find(b => b.Id == bookId);

        if (book is not null && !book.IsCheckedOut)
        {
            book.IsCheckedOut = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ReturnBook(int bookId)
    {
        var book = library.Books.Find(b => b.Id == bookId);

        if (book is not null && book.IsCheckedOut)
        {
            book.IsCheckedOut = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
