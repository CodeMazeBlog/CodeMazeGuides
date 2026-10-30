using WebApiBestPractices.Application.Dtos;

namespace WebApiBestPractices.Application.Services;

public interface IOwnerService
{
    Task<IReadOnlyList<OwnerDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<OwnerDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<OwnerDto> CreateAsync(OwnerForCreationDto owner, CancellationToken cancellationToken);
    Task UpdateAsync(Guid id, OwnerForUpdateDto owner, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
