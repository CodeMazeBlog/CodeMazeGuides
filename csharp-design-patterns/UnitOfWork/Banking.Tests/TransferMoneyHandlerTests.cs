using Banking.Application;
using Banking.Domain;

namespace Banking.Tests;

public class TransferMoneyHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenFundsAreAvailable_MovesMoneyAndSavesOnce()
    {
        var alice = Account.Open("Alice", 100m);
        var bob = Account.Open("Bob", 50m);
        var transfers = new FakeTransferRepository();
        var unitOfWork = new FakeUnitOfWork();
        var handler = new TransferMoneyHandler(
            new FakeAccountRepository(new() { [1] = alice, [2] = bob }), transfers, unitOfWork);

        var result = await handler.HandleAsync(
            new TransferMoneyCommand(1, 2, 30m, "TR-1"), TestContext.Current.CancellationToken);

        Assert.True(result.IsSuccess);
        Assert.Equal(70m, alice.Balance);
        Assert.Equal(80m, bob.Balance);
        Assert.Single(transfers.Added);
        Assert.Equal(1, unitOfWork.SaveCount);
    }

    [Fact]
    public async Task HandleAsync_WhenFundsAreShort_SavesNothing()
    {
        var alice = Account.Open("Alice", 100m);
        var bob = Account.Open("Bob", 50m);
        var transfers = new FakeTransferRepository();
        var unitOfWork = new FakeUnitOfWork();
        var handler = new TransferMoneyHandler(
            new FakeAccountRepository(new() { [1] = alice, [2] = bob }), transfers, unitOfWork);

        var result = await handler.HandleAsync(
            new TransferMoneyCommand(1, 2, 500m, "TR-2"), TestContext.Current.CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal("Account.InsufficientFunds", result.Error!.Code);
        Assert.Equal(100m, alice.Balance);
        Assert.Empty(transfers.Added);
        Assert.Equal(0, unitOfWork.SaveCount);
    }
}

internal sealed class FakeAccountRepository(Dictionary<int, Account> accounts) : IAccountRepository
{
    public Task<Account?> GetByIdAsync(int accountId, CancellationToken cancellationToken = default) =>
        Task.FromResult(accounts.GetValueOrDefault(accountId));
}

internal sealed class FakeTransferRepository : ITransferRepository
{
    public List<Transfer> Added { get; } = [];

    public void Add(Transfer transfer) => Added.Add(transfer);
}

internal sealed class FakeUnitOfWork : IUnitOfWork
{
    public int SaveCount { get; private set; }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SaveCount++;
        return Task.CompletedTask;
    }
}
