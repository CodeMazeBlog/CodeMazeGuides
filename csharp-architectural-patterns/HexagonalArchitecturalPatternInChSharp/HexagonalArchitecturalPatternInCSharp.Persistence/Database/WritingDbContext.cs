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

    public void SeedData()
    {
        var author1 = new Author
        {
            Id = Guid.NewGuid(),
            Name = "Author 1",
            Balance = 0,
        };

        var author2 = new Author
        {
            Id = Guid.NewGuid(),
            Name = "Author 2",
            Balance = 0,
        };

        Authors.Add(author1);
        Authors.Add(author2);

        SaveChanges();

        var article1 = new Article
        {
            Id = Guid.NewGuid(),
            Title = "Title 1",
            Description = "Description 1",
            Difficulty = Difficulty.Beginner,
        };

        var article2 = new Article
        {
            Id = Guid.NewGuid(),
            Title = "Title 2",
            Description = "Description 2",
            Difficulty = Difficulty.Intermediate,
            AuthorId = author1.Id,
        };

        var article3 = new Article
        {
            Id = Guid.NewGuid(),
            Title = "Title 3",
            Description = "Description 3",
            Difficulty = Difficulty.Expert,
        };

        Articles.Add(article1);
        Articles.Add(article2);
        Articles.Add(article3);

        SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("WritingDb");
    }
}