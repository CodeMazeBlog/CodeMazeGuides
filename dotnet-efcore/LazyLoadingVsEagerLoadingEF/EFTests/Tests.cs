namespace EFTests;

public class Tests
{
    private readonly DataContext _context;

    public Tests()
    {
        _context = new DataContext();
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        var author1 = new Author { Name = "Author 1" };
        var author2 = new Author { Name = "Author 2" };

        var book1 = new Book { Title = "Book 1", AuthorId = 1 };
        var book2 = new Book { Title = "Book 2", AuthorId = 2 };

        _context.Authors.AddRange(author1, author2);
        _context.Books.AddRange(book1, book2);

        _context.Database.EnsureCreated();
        _context.SaveChanges();
    }

    [Fact]
    public void GivenLazyLoading_WhenAuthorRetrieved_ThenBooksLoadedLazily()
    {
        var authorLazyLoading = _context.Authors.FirstOrDefault(a => a.AuthorId == 1);

        Assert.NotNull(authorLazyLoading);

        Assert.True(authorLazyLoading.Books.Any());
    }

    [Fact]
    public void GivenEagerLoading_WhenAuthorRetrieved_ThenBooksLoadedEagerly()
    {
        var authorEagerLoading = _context.Authors
            .Include(a => a.Books)
            .FirstOrDefault(a => a.AuthorId == 1);

        Assert.NotNull(authorEagerLoading);

        Assert.True(authorEagerLoading.Books.Any());
    }
}