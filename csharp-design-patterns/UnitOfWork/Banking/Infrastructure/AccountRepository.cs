using Banking.Application;
using Banking.Domain;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure;

public sealed class AccountRepository(BankDbContext dbContext) : IAccountRepository
{
    public Task<Account?> GetByIdAsync(int accountId, CancellationToken cancellationToken = default) =>
        dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == accountId, cancellationToken);
}
