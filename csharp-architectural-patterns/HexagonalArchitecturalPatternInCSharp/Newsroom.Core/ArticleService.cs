using Newsroom.Core.Ports.Driven;
using Newsroom.Core.Ports.Driving;

namespace Newsroom.Core;

public sealed class ArticleService(IArticleRepository articles, ISubscriberNotifier notifier)
    : IArticleService
{
    public async Task<ArticleDetails> CreateDraftAsync(
        string title, CancellationToken cancellationToken = default)
    {
        var article = Article.CreateDraft(title);

        articles.Add(article);
        await articles.SaveChangesAsync(cancellationToken);

        return ToDetails(article);
    }

    public async Task<Result<ArticleDetails>> GetAsync(
        int articleId, CancellationToken cancellationToken = default)
    {
        var article = await articles.GetByIdAsync(articleId, cancellationToken);
        if (article is null)
            return ArticleErrors.NotFound(articleId);

        return ToDetails(article);
    }

    public async Task<Result<ArticleDetails>> PublishAsync(
        int articleId, CancellationToken cancellationToken = default)
    {
        var article = await articles.GetByIdAsync(articleId, cancellationToken);
        if (article is null)
            return ArticleErrors.NotFound(articleId);

        var publishing = article.Publish();
        if (!publishing.IsSuccess)
            return publishing.Error!;

        await articles.SaveChangesAsync(cancellationToken);
        await notifier.NotifyAsync(new ArticlePublished(article.Id, article.Title), cancellationToken);

        return ToDetails(article);
    }

    private static ArticleDetails ToDetails(Article article) =>
        new(article.Id, article.Title, article.Status.ToString());
}
