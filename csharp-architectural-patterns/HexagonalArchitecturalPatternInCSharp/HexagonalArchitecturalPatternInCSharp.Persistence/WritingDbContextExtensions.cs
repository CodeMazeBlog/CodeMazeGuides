using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using HexagonalArchitecturalPatternInCSharp.Persistence.Database;

namespace HexagonalArchitecturalPatternInCSharp.Persistence;

public static class WritingDbContextExtensions
{
    public static void AddSeedData(this WritingDbContext dbContext)
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

        dbContext.Authors.Add(author1);
        dbContext.Authors.Add(author2);

        dbContext.SaveChanges();

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

        dbContext.Articles.Add(article1);
        dbContext.Articles.Add(article2);
        dbContext.Articles.Add(article3);

        dbContext.SaveChanges();
    }
}