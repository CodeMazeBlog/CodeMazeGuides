namespace Newsroom.Core;

public enum ArticleStatus
{
    Draft,
    Published
}

public sealed class Article
{
    private Article(string title) => Title = title;

    public int Id { get; private set; }
    public string Title { get; private set; }
    public ArticleStatus Status { get; private set; }

    public static Article CreateDraft(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        return new Article(title);
    }

    public Result Publish()
    {
        if (Status == ArticleStatus.Published)
            return ArticleErrors.AlreadyPublished(Id);

        Status = ArticleStatus.Published;

        return Result.Success();
    }
}
