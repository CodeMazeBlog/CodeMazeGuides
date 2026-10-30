using System.Collections.Concurrent;
using WebApiBestPractices.Domain.Contracts;
using WebApiBestPractices.Domain.Entities;

namespace WebApiBestPractices.Infrastructure.Repositories;

// Stands in for a database so the sample runs with no setup.
public class InMemoryOwnerRepository : IOwnerRepository
{
    public static readonly Guid JohnId = Guid.Parse("3f2b8c1e-6a4d-4e5f-9b7a-1c2d3e4f5a6b");
    public static readonly Guid AnnaId = Guid.Parse("8d9e0f1a-2b3c-4d5e-8f90-a1b2c3d4e5f6");

    private readonly ConcurrentDictionary<Guid, Owner> _owners = new()
    {
        [JohnId] = new Owner { Id = JohnId, Name = "John Keen", Email = "john@example.com", Address = "61 Wellfield Road" },
        [AnnaId] = new Owner { Id = AnnaId, Name = "Anna Bosh", Email = "anna@example.com", Address = "27 Colored Row" }
    };

    public Task<IReadOnlyList<Owner>> GetAllAsync(CancellationToken cancellationToken) =>
        Task.FromResult<IReadOnlyList<Owner>>(_owners.Values.OrderBy(o => o.Name).ToList());

    public Task<Owner?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        Task.FromResult(_owners.GetValueOrDefault(id));

    public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken) =>
        Task.FromResult(_owners.Values.Any(o => string.Equals(o.Email, email, StringComparison.OrdinalIgnoreCase)));

    public Task AddAsync(Owner owner, CancellationToken cancellationToken)
    {
        _owners[owner.Id] = owner;
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Owner owner, CancellationToken cancellationToken)
    {
        _owners[owner.Id] = owner;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        _owners.TryRemove(id, out _);
        return Task.CompletedTask;
    }
}
