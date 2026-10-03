using Banking.Domain;

namespace Banking.UnitTests;

public class AccountTests
{
    [Fact]
    public void Withdraw_WhenTheBalanceCoversIt_TakesTheMoney()
    {
        var account = Account.Open("Anna Smith", initialDeposit: 100m);

        var result = account.Withdraw(30m);

        Assert.True(result.IsSuccess);
        Assert.Equal(70m, account.Balance);
    }

    [Fact]
    public void Withdraw_WhenTheBalanceIsTooLow_ReturnsAnErrorAndKeepsTheMoney()
    {
        var account = Account.Open("Mark Jones", initialDeposit: 20m);

        var result = account.Withdraw(50m);

        Assert.False(result.IsSuccess);
        Assert.Equal("Account.InsufficientFunds", result.Error!.Code);
        Assert.Equal(20m, account.Balance);
    }
}
