namespace BooksService.Models;

public class Book
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public required string Name { get; set; }
    public int NumberOfPages { get; set; }
}
