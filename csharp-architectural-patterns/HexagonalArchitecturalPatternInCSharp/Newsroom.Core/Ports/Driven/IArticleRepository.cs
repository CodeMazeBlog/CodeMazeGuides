namespace Newsroom.Core.Ports.Driven;

public interface IArticleRepository
{
    Task<Article?> GetByIdAsync(int articleId, CancellationToken cancellationToken = default);

    void Add(Article article);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
