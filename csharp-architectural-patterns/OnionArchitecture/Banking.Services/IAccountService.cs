using Banking.Domain;

namespace Banking.Services;

public sealed record AccountDto(int Id, string Owner, decimal Balance);

public interface IAccountService
{
    Task<Result<AccountDto>> GetByIdAsync(int accountId, CancellationToken cancellationToken = default);

    Task<Result<AccountDto>> WithdrawAsync(int accountId, decimal amount, CancellationToken cancellationToken = default);
}
