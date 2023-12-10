using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driven;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driving;

namespace HexagonalArchitecturalPatternInCSharp.Core.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task AddAsync(Article article)
    {
        await _articleRepository.AddAsync(article);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _articleRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Article>> GetAllAsync()
    {
        return await _articleRepository.GetAllAsync();
    }

    public async Task<Article?> GetByIdAsync(Guid id)
    {
        return await _articleRepository.GetByIdAsync(id);
    }
}
