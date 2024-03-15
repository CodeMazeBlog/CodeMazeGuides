using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driven;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecturalPatternInCSharp.Persistence.Database;

public class ArticleRepository : IArticleRepository
{
    private readonly WritingDbContext _dbContext;

    public ArticleRepository(WritingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Article article)
    {
        await _dbContext.Articles.AddAsync(article);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var article = _dbContext.Articles.FirstOrDefault(x => x.Id == id);

        if (article != null)
        {
            _dbContext.Articles.Remove(article);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Article>> GetAllAsync()
    {
        return await _dbContext.Articles.AsNoTracking().ToListAsync();
    }

    public async Task<Article?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Articles.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Article article)
    {
        _dbContext.Articles.Entry(article).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}