using Newsroom.Core;
using Newsroom.Core.Ports.Driven;

namespace Newsroom.Tests;

internal sealed class FakeArticleRepository(Article? stored) : IArticleRepository
{
    public int SaveCount { get; private set; }

    public Task<Article?> GetByIdAsync(int articleId, CancellationToken cancellationToken = default) =>
        Task.FromResult(stored);

    public void Add(Article article) => stored = article;

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SaveCount++;
        return Task.CompletedTask;
    }
}

internal sealed class FakeSubscriberNotifier : ISubscriberNotifier
{
    public List<ArticlePublished> Sent { get; } = [];

    public Task NotifyAsync(ArticlePublished message, CancellationToken cancellationToken = default)
    {
        Sent.Add(message);
        return Task.CompletedTask;
    }
}
