namespace LINQLikeOperator;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    public DbSet<Article> Articles { get; set; }
}
