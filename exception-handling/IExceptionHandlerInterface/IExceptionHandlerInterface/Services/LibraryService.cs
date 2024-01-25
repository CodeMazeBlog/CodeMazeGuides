using IExceptionHandlerInterface.Models;

namespace IExceptionHandlerInterface.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly List<Book> _books;

        public LibraryService() => _books = [
            new Book { Id = 1, Title = "The Catcher in the Rye", Author = "J.D. Salinger" },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee" },
            new Book { Id = 3, Title = "1984", Author = "George Orwell" }
        ];

        public Book GetById(int id)
        {
            return _books.Find(book => book.Id == id);
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }
    }
}