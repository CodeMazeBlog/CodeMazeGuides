using Microsoft.Extensions.Logging;
using Newsroom.Core.Ports.Driven;

namespace Newsroom.Notifications;

public sealed class LoggingSubscriberNotifier(ILogger<LoggingSubscriberNotifier> logger)
    : ISubscriberNotifier
{
    public Task NotifyAsync(ArticlePublished message, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Telling subscribers about article {ArticleId}: {Title}",
            message.ArticleId, message.Title);

        return Task.CompletedTask;
    }
}
