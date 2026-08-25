using AuthorsService.Models;

namespace AuthorsService.Data;

public class Repository
{
    private readonly IEnumerable<Author> _authors =
    [
        new Author { AuthorId = 1, Name = "John Doe", Country = "Australia" },
        new Author { AuthorId = 2, Name = "Jane Smith", Country = "United States" }
    ];

    private readonly DateTime _startTime = DateTime.UtcNow;
    private bool _shouldFail = true;

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        if (_shouldFail)
        {
            _shouldFail = false;

            throw new InvalidOperationException("Oops!");
        }

        if (_startTime.AddMinutes(1) > DateTime.UtcNow)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));

            throw new TimeoutException("Timeout!");
        }

        return _authors;
    }
}
