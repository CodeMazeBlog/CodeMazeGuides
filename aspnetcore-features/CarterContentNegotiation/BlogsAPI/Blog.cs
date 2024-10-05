public class Blog
{
    public int Id { get; init; }
    public DateOnly DatePublished { get; init; }
    public string? Title { get; init; }
    public string[]? Tags { get; init; }
}