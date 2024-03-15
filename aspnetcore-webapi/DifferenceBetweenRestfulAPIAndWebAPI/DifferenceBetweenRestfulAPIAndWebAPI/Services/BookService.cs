using DifferenceBetweenRestfulAPIAndWebAPI.Interfaces;
using DifferenceBetweenRestfulAPIAndWebAPI.Models;

namespace DifferenceBetweenRestfulAPIAndWebAPI.Services
{
    public class BookService : IBookService
    {
        private List<Book> Books { get; set; } =
        [
           new() { Id = 1, Title = "Book 1" },
            new() { Id = 2, Title = "Book 2" },
            new() { Id = 3, Title = "Book 3" }
        ];

        public List<Book> GetAllBooks() => Books;
    }
}