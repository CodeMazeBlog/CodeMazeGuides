namespace Newsroom.Core.Ports.Driving;

public sealed record ArticleDetails(int Id, string Title, string Status);

public interface IArticleService
{
    Task<ArticleDetails> CreateDraftAsync(string title, CancellationToken cancellationToken = default);

    Task<Result<ArticleDetails>> GetAsync(int articleId, CancellationToken cancellationToken = default);

    Task<Result<ArticleDetails>> PublishAsync(int articleId, CancellationToken cancellationToken = default);
}
