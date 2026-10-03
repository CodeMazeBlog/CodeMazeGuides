using Banking.Domain;

namespace Banking.Services;

internal sealed class AccountService(IAccountRepository accounts) : IAccountService
{
    public async Task<Result<AccountDto>> GetByIdAsync(
        int accountId, CancellationToken cancellationToken = default)
    {
        var account = await accounts.GetByIdAsync(accountId, cancellationToken);
        if (account is null)
            return AccountErrors.NotFound(accountId);

        return ToDto(account);
    }

    public async Task<Result<AccountDto>> WithdrawAsync(
        int accountId, decimal amount, CancellationToken cancellationToken = default)
    {
        var account = await accounts.GetByIdAsync(accountId, cancellationToken);
        if (account is null)
            return AccountErrors.NotFound(accountId);

        var withdrawal = account.Withdraw(amount);
        if (!withdrawal.IsSuccess)
            return withdrawal.Error!;

        await accounts.SaveChangesAsync(cancellationToken);

        return ToDto(account);
    }

    private static AccountDto ToDto(Account account) =>
        new(account.Id, account.Owner, account.Balance);
}
