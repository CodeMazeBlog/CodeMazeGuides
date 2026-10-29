using WebApiBestPractices.Domain.Entities;

namespace WebApiBestPractices.Domain.Contracts;

public interface IOwnerRepository
{
    Task<IReadOnlyList<Owner>> GetAllAsync(CancellationToken cancellationToken);
    Task<Owner?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);
    Task AddAsync(Owner owner, CancellationToken cancellationToken);
    Task UpdateAsync(Owner owner, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
