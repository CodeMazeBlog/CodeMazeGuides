namespace LINQLikeOperatorTests;

public class DatabaseFixture : IDisposable
{
    public string startsWithN = "nop";
    public string containsN = "mnp";
    public string endsWithN = "lmn";
    public string notIncludeN = "abc";
    public BlogDbContext? blogDbContext;

    public DatabaseFixture()
    {
        DbContextOptions<BlogDbContext> contextOption = new DbContextOptionsBuilder<BlogDbContext>()
           .UseInMemoryDatabase("BlobDb")
           .Options;
        blogDbContext = new BlogDbContext(contextOption);
        blogDbContext.Articles.Add(new() { Id = 1, Title = startsWithN });
        blogDbContext.Articles.Add(new() { Id = 2, Title = containsN });
        blogDbContext.Articles.Add(new() { Id = 3, Title = endsWithN });
        blogDbContext.Articles.Add(new() { Id = 4, Title = notIncludeN });
        blogDbContext.SaveChanges();
    }

    public void Dispose()
    {
        if (blogDbContext is not null)
        {
            blogDbContext.Dispose();
        }
    }
}
