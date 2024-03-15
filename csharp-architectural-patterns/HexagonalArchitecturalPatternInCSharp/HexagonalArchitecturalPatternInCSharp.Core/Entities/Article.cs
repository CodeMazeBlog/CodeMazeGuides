namespace HexagonalArchitecturalPatternInCSharp.Core.Entities;

public class Article
{
    public Guid Id { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public Difficulty Difficulty { get; set; }

    public WritingStatus WritingStatus { get; set; }

    public Guid? AuthorId { get; set; }
}