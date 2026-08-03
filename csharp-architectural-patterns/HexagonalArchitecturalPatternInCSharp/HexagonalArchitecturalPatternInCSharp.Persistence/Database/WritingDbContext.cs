using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecturalPatternInCSharp.Persistence.Database;

public class WritingDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }

    public DbSet<Article> Articles { get; set; }

    public WritingDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("WritingDb");
    }
}