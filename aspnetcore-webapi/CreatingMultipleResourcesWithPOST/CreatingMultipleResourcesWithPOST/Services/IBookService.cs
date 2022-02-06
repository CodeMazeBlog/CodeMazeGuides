using CreatingMultipleResorcesWithPOST.Models;

namespace CreatingMultipleResorcesWithPOST.Services
{
    public interface IBookService
    {
        IEnumerable<BookModel> GetBooks();

        BookModel CreateBook(BookRequest bookRequest);

        IEnumerable<MultipleBooksBase> CreateBooks(IEnumerable<BookRequest> bookRequests);
    }
}
