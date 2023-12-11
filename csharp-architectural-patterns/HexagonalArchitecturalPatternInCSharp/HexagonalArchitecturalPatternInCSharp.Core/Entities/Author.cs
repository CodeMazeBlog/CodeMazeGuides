namespace HexagonalArchitecturalPatternInCSharp.Core.Entities;

public class Author
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public double Balance { get; set; }
}