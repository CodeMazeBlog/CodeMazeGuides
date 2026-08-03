using Domain.Entities;

namespace Domain.Repositories;

public interface ICatRepository
{
    Task<IEnumerable<Cat>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Cat?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Insert(Cat cat);
    void Remove(Cat cat);
}
