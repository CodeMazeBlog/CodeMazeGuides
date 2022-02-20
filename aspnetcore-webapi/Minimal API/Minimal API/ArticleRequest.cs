namespace Minimal_API;

public record ArticleRequest(string? Title, string? Content, DateTime? PublishedAt);