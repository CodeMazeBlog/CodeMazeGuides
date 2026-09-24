using EventTicketing.Application.Abstractions;

namespace EventTicketing.Infrastructure.Persistence;

public sealed class UnitOfWork(TicketingDbContext dbContext) : IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
