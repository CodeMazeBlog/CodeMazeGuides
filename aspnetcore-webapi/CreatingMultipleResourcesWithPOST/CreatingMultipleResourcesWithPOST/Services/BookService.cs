using CreatingMultipleResorcesWithPOST.Infrastructure;
using CreatingMultipleResorcesWithPOST.Models;

namespace CreatingMultipleResorcesWithPOST.Services
{
    public class BookService : IBookService
    {
        private readonly ApiContext _context;

        public BookService(ApiContext context)
        {
            _context = context;
        }

        public IEnumerable<MultipleBooksBase> CreateBooks(IEnumerable<BookRequest> bookRequests)
        {
            var books = new List<MultipleBooksBase>();

            foreach (var bookRequest in bookRequests)
            {
                try
                {
                    var bookModel = _context.BookModels.Add(new BookModel(0, bookRequest.Name, bookRequest.Isbn));
                    _context.SaveChanges();

                    books.Add(new MultipleBooksModel("201", bookModel.Entity));
                }
                catch (Exception)
                {
                    books.Add(new MultipleBooksErrorModel("500", "Internal error while creating a resource"));

                    _context.ChangeTracker.Clear();
                }
            }

            return books;
        }
    }
}