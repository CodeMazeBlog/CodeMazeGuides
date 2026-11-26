namespace LINQLikeOperatorTests;

public class DatabaseFixture : IDisposable
{
    internal string startsWithN = "nop";
    internal string containsN = "mnp";
    internal string endsWithN = "lmn";
    internal string notContainsN = "abc";
    internal string percentTitle = "50% off";
    internal string digitsTitle = "50 tips";
    internal BlogDbContext? blogDbContext;

    public DatabaseFixture()
    {
        var contextOption = new DbContextOptionsBuilder<BlogDbContext>()
           .UseInMemoryDatabase("BlobDb")
           .Options;

        blogDbContext = new BlogDbContext(contextOption);
        blogDbContext.Articles.Add(new() { Id = 1, Title = startsWithN });
        blogDbContext.Articles.Add(new() { Id = 2, Title = containsN });
        blogDbContext.Articles.Add(new() { Id = 3, Title = endsWithN });
        blogDbContext.Articles.Add(new() { Id = 4, Title = notContainsN });
        blogDbContext.Articles.Add(new() { Id = 5, Title = percentTitle });
        blogDbContext.Articles.Add(new() { Id = 6, Title = digitsTitle });

        blogDbContext.SaveChanges();
    }

    public void Dispose()
    {
        blogDbContext?.Dispose();
    }
}
