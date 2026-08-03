using IExceptionHandlerInterface.Models;

namespace IExceptionHandlerInterface.Services;

public interface ILibraryService
{
    Book GetById(int id);
    List<Book> GetAllBooks();
}
