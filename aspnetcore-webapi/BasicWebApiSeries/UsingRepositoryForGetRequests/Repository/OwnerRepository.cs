using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        // FindAll and FindByCondition stay synchronous: they compose a query, they do
        // not execute one. The awaited call is the one that executes.
        public async Task<IEnumerable<Owner>> GetAllOwnersAsync() =>
            await FindAll()
                .OrderBy(ow => ow.Name)
                .ToListAsync();

        public async Task<Owner?> GetOwnerByIdAsync(Guid ownerId) =>
            await FindByCondition(owner => owner.Id.Equals(ownerId))
                .FirstOrDefaultAsync();

        public async Task<Owner?> GetOwnerWithDetailsAsync(Guid ownerId) =>
            await FindByCondition(owner => owner.Id.Equals(ownerId))
                .Include(ac => ac.Accounts)
                .FirstOrDefaultAsync();
    }
}
