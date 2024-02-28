public class BankAccountTests
{
    [Fact]
    public void GivenValidDepositAmount_WhenDepositCalled_ThenBalanceIncreased()
    {
        // Arrange
        BankAccount account = new BankAccount("1234567890");
        var initialBalance = account.Balance;
        var depositAmount = 100;

        // Act
        account.Deposit(depositAmount);
        var newBalance = account.Balance;

        // Assert
        Assert.Equal(initialBalance + depositAmount, newBalance);
    }

    [Fact]
    public void GivenInvalidDepositAmount_WhenDepositCalled_ThenBalanceRemainsSame()
    {
        // Arrange
        BankAccount account = new BankAccount("1234567890");
        var initialBalance = account.Balance;
        var invalidDepositAmount = -50;

        // Act
        account.Deposit(invalidDepositAmount);
        var newBalance = account.Balance;

        // Assert
        Assert.Equal(initialBalance, newBalance);
    }

    [Fact]
    public void GivenValidWithdrawalAmount_WhenWithdrawCalled_ThenBalanceDecreased()
    {
        // Arrange
        BankAccount account = new BankAccount("1234567890");
        account.Deposit(200);
        var initialBalance = account.Balance;
        var withdrawalAmount = 100;

        // Act
        account.Withdraw(withdrawalAmount);
        var newBalance = account.Balance;

        // Assert
        Assert.Equal(initialBalance - withdrawalAmount, newBalance);
    }

    [Fact]
    public void GivenInvalidWithdrawalAmount_WhenWithdrawCalled_ThenBalanceRemainsSame()
    {
        // Arrange
        BankAccount account = new BankAccount("1234567890");
        account.Deposit(100);
        var initialBalance = account.Balance;
        var invalidWithdrawalAmount = -50;

        // Act
        account.Withdraw(invalidWithdrawalAmount);
        var newBalance = account.Balance;

        // Assert
        Assert.Equal(initialBalance, newBalance);
    }
}
