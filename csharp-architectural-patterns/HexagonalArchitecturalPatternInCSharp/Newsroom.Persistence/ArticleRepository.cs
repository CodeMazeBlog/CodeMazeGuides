using Microsoft.EntityFrameworkCore;
using Newsroom.Core;
using Newsroom.Core.Ports.Driven;

namespace Newsroom.Persistence;

public sealed class ArticleRepository(NewsroomDbContext dbContext) : IArticleRepository
{
    public Task<Article?> GetByIdAsync(int articleId, CancellationToken cancellationToken = default) =>
        dbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId, cancellationToken);

    public void Add(Article article) => dbContext.Articles.Add(article);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
