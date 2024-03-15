using Domain.Repositories;

namespace Persistence.Repositories;

internal sealed class UnitOfWork(CatsDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
     => context.SaveChangesAsync(cancellationToken);
}
