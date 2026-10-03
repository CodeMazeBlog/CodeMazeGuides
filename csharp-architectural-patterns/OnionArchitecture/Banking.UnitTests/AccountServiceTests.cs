using Banking.Domain;
using Banking.Services;

namespace Banking.UnitTests;

public class AccountServiceTests
{
    [Fact]
    public async Task WithdrawAsync_WhenTheBalanceCoversIt_SavesOnce()
    {
        var accounts = new FakeAccountRepository(Account.Open("Anna Smith", initialDeposit: 100m));
        var service = new AccountService(accounts);

        var result = await service.WithdrawAsync(
            accountId: 1, amount: 30m, TestContext.Current.CancellationToken);

        Assert.True(result.IsSuccess);
        Assert.Equal(70m, result.Value.Balance);
        Assert.Equal(1, accounts.SaveCount);
    }

    [Fact]
    public async Task WithdrawAsync_WhenTheBalanceIsTooLow_SavesNothing()
    {
        var accounts = new FakeAccountRepository(Account.Open("Mark Jones", initialDeposit: 20m));
        var service = new AccountService(accounts);

        var result = await service.WithdrawAsync(
            accountId: 2, amount: 50m, TestContext.Current.CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal("Account.InsufficientFunds", result.Error!.Code);
        Assert.Equal(0, accounts.SaveCount);
    }
}

internal sealed class FakeAccountRepository(Account? account) : IAccountRepository
{
    public int SaveCount { get; private set; }

    public Task<Account?> GetByIdAsync(int accountId, CancellationToken cancellationToken = default) =>
        Task.FromResult(account);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SaveCount++;
        return Task.CompletedTask;
    }
}
