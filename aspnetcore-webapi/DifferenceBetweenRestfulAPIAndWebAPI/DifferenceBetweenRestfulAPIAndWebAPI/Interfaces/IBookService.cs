using DifferenceBetweenRestfulAPIAndWebAPI.Models;

namespace DifferenceBetweenRestfulAPIAndWebAPI.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
    }
}