using AuthorsService.Models;

namespace AuthorsService.Data;

public class Repository
{
    private readonly IEnumerable<Author> _authors =
    [
        new Author { AuthorId = 1, Name = "John Doe", Country = "Australia" },
        new Author { AuthorId = 2, Name = "Jane Smith", Country = "United States" }
    ];

    public IEnumerable<Author> GetAuthors() => _authors;
}
