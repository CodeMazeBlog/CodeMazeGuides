using Banking.Domain;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure;

internal sealed class AccountRepository(BankingDbContext dbContext) : IAccountRepository
{
    public Task<Account?> GetByIdAsync(int accountId, CancellationToken cancellationToken = default) =>
        dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == accountId, cancellationToken);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
