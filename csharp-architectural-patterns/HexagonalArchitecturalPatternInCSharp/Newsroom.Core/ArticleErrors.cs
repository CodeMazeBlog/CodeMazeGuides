namespace Newsroom.Core;

public static class ArticleErrors
{
    public static Error NotFound(int articleId) =>
        new("Article.NotFound", $"Article {articleId} was not found.", ErrorType.NotFound);

    public static Error AlreadyPublished(int articleId) =>
        new("Article.AlreadyPublished", $"Article {articleId} is already published.", ErrorType.Conflict);
}
