namespace EFTests;

public class Tests
{
    [Fact]
    public void GivenLazyLoading_WhenAuthorRetrieved_ThenBooksLoadedLazily()
    {
        using var context = new DataContext();
        Seeder.SeedData(context);

        var authorLazyLoading = context.Authors.FirstOrDefault(a => a.AuthorId == 1);

        Assert.NotNull(authorLazyLoading);

        Assert.True(authorLazyLoading.Books.Any());
    }

    [Fact]
    public void GivenEagerLoading_WhenAuthorRetrieved_ThenBooksLoadedEagerly()
    {
        using var context = new DataContext();
        Seeder.SeedData(context);

        var authorEagerLoading = context.Authors
            .Include(a => a.Books)
            .FirstOrDefault(a => a.AuthorId == 1);

        Assert.NotNull(authorEagerLoading);

        Assert.True(authorEagerLoading.Books.Any());
    }
}