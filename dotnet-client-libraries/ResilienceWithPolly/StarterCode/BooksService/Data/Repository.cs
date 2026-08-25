using BooksService.Models;

namespace BooksService.Data;

public class Repository
{
    private readonly IEnumerable<Book> _books =
    [
        new Book { BookId = 1, AuthorId = 1, Name = "The Fallen Shore", NumberOfPages = 123 },
        new Book { BookId = 2, AuthorId = 1, Name = "Harmony of Joy", NumberOfPages = 211 },
        new Book { BookId = 3, AuthorId = 2, Name = "Aliens vs Robots", NumberOfPages = 345 }
    ];

    public IEnumerable<Book> GetBooks() => _books;
}
