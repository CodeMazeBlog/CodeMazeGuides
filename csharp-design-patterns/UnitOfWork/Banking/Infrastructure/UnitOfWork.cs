using Banking.Application;

namespace Banking.Infrastructure;

public sealed class UnitOfWork(BankDbContext dbContext) : IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
