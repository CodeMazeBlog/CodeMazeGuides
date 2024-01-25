using DifferenceBetweenRestfulAPIAndWebAPI.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace DifferenceBetweenRestfulAPIAndWebAPI.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
    }
}
