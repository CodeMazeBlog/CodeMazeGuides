using Banking.Domain;

namespace Banking.Application;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(int accountId, CancellationToken cancellationToken = default);
}
