using CreatingMultipleResorcesWithPOST.Models;

namespace CreatingMultipleResorcesWithPOST.Services
{
    public interface IBookService
    {
        IEnumerable<MultipleBooksBase> CreateBooks(IEnumerable<BookRequest> bookRequests);
    }
}
