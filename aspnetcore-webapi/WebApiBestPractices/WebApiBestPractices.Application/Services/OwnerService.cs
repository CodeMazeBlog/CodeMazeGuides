using Microsoft.Extensions.Caching.Hybrid;
using WebApiBestPractices.Application.Dtos;
using WebApiBestPractices.Application.Mapping;
using WebApiBestPractices.Domain.Contracts;
using WebApiBestPractices.Domain.Exceptions;

namespace WebApiBestPractices.Application.Services;

public class OwnerService(IOwnerRepository repository, HybridCache cache) : IOwnerService
{
    public async Task<IReadOnlyList<OwnerDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var owners = await repository.GetAllAsync(cancellationToken);

        return owners.Select(o => o.ToDto()).ToList();
    }

    public async Task<OwnerDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await cache.GetOrCreateAsync(
            $"owner-{id}",
            async token => (await repository.GetByIdAsync(id, token))?.ToDto(),
            cancellationToken: cancellationToken);

    public async Task<OwnerDto> CreateAsync(OwnerForCreationDto owner, CancellationToken cancellationToken)
    {
        if (await repository.EmailExistsAsync(owner.Email, cancellationToken))
            throw new DuplicateOwnerEmailException(owner.Email);

        var entity = owner.ToEntity();
        await repository.AddAsync(entity, cancellationToken);

        return entity.ToDto();
    }

    public async Task UpdateAsync(Guid id, OwnerForUpdateDto owner, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new KeyNotFoundException($"Owner {id} was not found.");

        entity.Name = owner.Name;
        entity.Address = owner.Address;
        await repository.UpdateAsync(entity, cancellationToken);
        await cache.RemoveAsync($"owner-{id}", cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(id, cancellationToken);
        await cache.RemoveAsync($"owner-{id}", cancellationToken);
    }
}
