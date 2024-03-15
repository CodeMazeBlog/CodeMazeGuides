using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LazyLoadingVsEagerLoadingEF;
public class DataContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlite($"DataSource=library.db")
            .LogTo(Console.WriteLine, LogLevel.Information);
    }
}
