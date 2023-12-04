using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driven;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driving;

namespace HexagonalArchitecturalPatternInCSharp.Core.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task AddAsync(Author author)
    {
        await _authorRepository.AddAsync(author);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _authorRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _authorRepository.GetAllAsync();
    }

    public async Task<Author?> GetByIdAsync(Guid id)
    {
        return await _authorRepository.GetByIdAsync(id);
    }
}
