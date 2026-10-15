using VolatileInterlockedLockInCsharp;

namespace Tests;

public class Tests
{
    [Fact]
    public void GivenBalanceWithoutSync_WhenMultipleWithdrawals_ThenFinalBalanceIsNotGuaranteed()
    {
        var account = new Account
        {
            Balance = 100000
        };

        AccountService.WithdrawBalance(account.Withdraw);

        // A race is not deterministic: this demonstrates the race, it cannot prove it happened.
        Assert.InRange(account.Balance, 0, 100000);
    }

    [Fact]
    public void GivenBalanceVolatile_WhenMultipleWithdrawals_ThenFinalBalanceIsNotGuaranteed()
    {
        var account = new Account
        {
            BalanceVolatile = 100000
        };

        AccountService.WithdrawBalance(account.WithdrawVolatile);

        // A race is not deterministic: this demonstrates the race, it cannot prove it happened.
        Assert.InRange(account.BalanceVolatile, 0, 100000);
    }

    [Fact]
    public void GivenBalanceWithLock_WhenMultipleWithdrawals_ThenFinalBalanceIsCorrect()
    {
        var account = new Account
        {
            BalanceLock = 100000
        };

        AccountService.WithdrawBalance(account.WithdrawLock);

        Assert.Equal(0, account.BalanceLock);
    }

    [Fact]
    public void GivenBalanceWithInterlocked_WhenMultipleWithdrawals_ThenFinalBalanceIsCorrect()
    {
        var account = new Account
        {
            BalanceInterlocked = 100000
        };

        AccountService.WithdrawBalance(account.WithdrawInterlocked);

        Assert.Equal(0, account.BalanceInterlocked);
    }

    [Fact]
    public void GivenCompareExchangeLoop_WhenConcurrentWithdrawals_ThenEveryWithdrawalSucceedsAndBalanceIsZero()
    {
        var account = new Account
        {
            BalanceInterlocked = 100000
        };
        var succeeded = 0;

        Parallel.For(0, 1000, _ =>
        {
            if (account.WithdrawIfSufficient(100))
                Interlocked.Increment(ref succeeded);
        });

        Assert.Equal(1000, succeeded);
        Assert.Equal(0, account.BalanceInterlocked);
        Assert.False(account.WithdrawIfSufficient(100));
    }

    [Fact]
    public void GivenOneShotInitializer_WhenManyThreadsTryToStart_ThenExactlyOneWins()
    {
        var initializer = new OneShotInitializer();
        var winners = 0;

        Parallel.For(0, 1000, _ =>
        {
            if (initializer.TryStart())
                Interlocked.Increment(ref winners);
        });

        Assert.Equal(1, winners);
    }
}