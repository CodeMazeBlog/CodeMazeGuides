using VolatileInterlockedLockInCsharp;

namespace Tests;

public class Tests
{
    [Fact]
    public void GivenBalanceWithoutSync_WhenMultipleWithdrawals_ThenFinalBalanceIsIncorrect()
    {
        var account = new Account
        {
            Balance = 100000
        };

        AccountService.WithdrawBalance(account.Withdraw);

        Assert.NotEqual(100000, account.Balance);
    }

    [Fact]
    public void GivenBalanceVolatile_WhenMultipleWithdrawals_ThenFinalBalanceIsIncorrect()
    {
        var account = new Account
        {
            BalanceVolatile = 100000
        };

        AccountService.WithdrawBalance(account.WithdrawVolatile);

        Assert.NotEqual(1000, account.BalanceVolatile);
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
}