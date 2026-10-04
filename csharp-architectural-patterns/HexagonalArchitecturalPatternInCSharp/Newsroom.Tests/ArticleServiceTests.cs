using Newsroom.Core;
using Newsroom.Core.Ports.Driving;

namespace Newsroom.Tests;

public class ArticleServiceTests
{
    [Fact]
    public async Task PublishAsync_WhenArticleIsADraft_PublishesAndNotifiesOnce()
    {
        var articles = new FakeArticleRepository(Article.CreateDraft("Ports and Adapters in C#"));
        var notifier = new FakeSubscriberNotifier();
        IArticleService service = new ArticleService(articles, notifier);

        var result = await service.PublishAsync(articleId: 1, TestContext.Current.CancellationToken);

        Assert.True(result.IsSuccess);
        Assert.Equal("Published", result.Value.Status);
        Assert.Equal(1, articles.SaveCount);
        Assert.Single(notifier.Sent);
    }

    [Fact]
    public async Task PublishAsync_WhenAlreadyPublished_ReturnsConflictAndNotifiesNobody()
    {
        var article = Article.CreateDraft("Ports and Adapters in C#");
        article.Publish();
        var articles = new FakeArticleRepository(article);
        var notifier = new FakeSubscriberNotifier();
        IArticleService service = new ArticleService(articles, notifier);

        var result = await service.PublishAsync(articleId: 1, TestContext.Current.CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal("Article.AlreadyPublished", result.Error!.Code);
        Assert.Equal(0, articles.SaveCount);
        Assert.Empty(notifier.Sent);
    }
}
