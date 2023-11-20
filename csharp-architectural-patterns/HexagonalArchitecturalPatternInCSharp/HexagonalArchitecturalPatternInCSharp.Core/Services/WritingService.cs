using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driven;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driving;

namespace HexagonalArchitecturalPatternInCSharp.Core.Services;

public class WritingService : IWritingService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IArticleRepository _articleRepository;

    public WritingService(IAuthorRepository authorRepository, IArticleRepository articleRepository)
    {
        _authorRepository = authorRepository;
        _articleRepository = articleRepository;
    }

    public async Task ChangeArticleStatusAsync(Guid articleId, WritingStatus writingStatus)
    {
        var article = await _articleRepository.GetByIdAsync(articleId);
        if (article == null)
        {
            return;
        }

        article.WritingStatus = writingStatus;
        await _articleRepository.UpdateAsync(article);
    }

    public async Task StartWritingAsync(Guid authorId, Guid articleId)
    {
        var author = await _authorRepository.GetByIdAsync(authorId);      
        if (author == null)
        {
            return;
        }

        var article = await _articleRepository.GetByIdAsync(articleId); 
        if (article == null) 
        {
            return;
        }

        article.AuthorId = author.Id;
        await _articleRepository.UpdateAsync(article);

    }
}
