using HexagonalArchitecturalPatternInCSharp.Core.Entities;

namespace HexagonalArchitecturalPatternInCSharp.Core.Ports.Driven;

public interface IAuthorRepository
{
    Task AddAsync(Author author);

    Task<IEnumerable<Author>> GetAllAsync();

    Task<Author?> GetByIdAsync(Guid id);

    Task DeleteAsync(Guid id);
}