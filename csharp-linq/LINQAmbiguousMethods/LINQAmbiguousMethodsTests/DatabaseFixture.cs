namespace LINQAmbiguousMethodsTests;

public class DatabaseFixture : IDisposable
{
    internal string title1 = "title 1";
    internal string title2 = "title 2";
    internal string someTitle = "Some Title";
    internal BlogDbContext? blogDbContext;

    public DatabaseFixture()
    {
        var contextOption = new DbContextOptionsBuilder<BlogDbContext>()
           .UseInMemoryDatabase("BlobDb")
           .Options;

        blogDbContext = new BlogDbContext(contextOption);
        blogDbContext.Articles!.Add(new() { Id = 1, Title = title1 });
        blogDbContext.Articles!.Add(new() { Id = 2, Title = title2 });
        blogDbContext.Articles!.Add(new() { Id = 3, Title = someTitle });

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