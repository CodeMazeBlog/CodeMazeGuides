namespace LINQAmbiguousMethods;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
    }

    public DbSet<Article>? Articles { get; set; }
}
