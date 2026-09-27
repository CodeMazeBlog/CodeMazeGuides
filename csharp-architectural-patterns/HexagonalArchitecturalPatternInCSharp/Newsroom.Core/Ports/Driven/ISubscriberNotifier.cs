namespace Newsroom.Core.Ports.Driven;

public sealed record ArticlePublished(int ArticleId, string Title);

public interface ISubscriberNotifier
{
    Task NotifyAsync(ArticlePublished message, CancellationToken cancellationToken = default);
}
