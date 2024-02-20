public class BankAccountTests
{
    [Fact]
    public void GivenValidDepositAmount_WhenDepositCalled_ThenBalanceIncreased()
    {
        // Arrange
        BankAccount account = new BankAccount("1234567890");
        decimal initialBalance = account.Balance;
        decimal depositAmount = 100;

        // Act
        account.Deposit(depositAmount);
        decimal newBalance = account.Balance;

        // Assert
        Assert.Equal(initialBalance + depositAmount, newBalance);
    }

    [Fact]
    public void GivenInvalidDepositAmount_WhenDepositCalled_ThenBalanceRemainsSame()
    {
        // Arrange
        BankAccount account = new BankAccount("1234567890");
        decimal initialBalance = account.Balance;
        decimal invalidDepositAmount = -50;

        // Act
        account.Deposit(invalidDepositAmount);
        decimal newBalance = account.Balance;

        // Assert
        Assert.Equal(initialBalance, newBalance);
    }

    [Fact]
    public void GivenValidWithdrawalAmount_WhenWithdrawCalled_ThenBalanceDecreased()
    {
        // Arrange
        BankAccount account = new BankAccount("1234567890");
        account.Deposit(200);
        decimal initialBalance = account.Balance;
        decimal withdrawalAmount = 100;

        // Act
        account.Withdraw(withdrawalAmount);
        decimal newBalance = account.Balance;

        // Assert
        Assert.Equal(initialBalance - withdrawalAmount, newBalance);
    }

    [Fact]
    public void GivenInvalidWithdrawalAmount_WhenWithdrawCalled_ThenBalanceRemainsSame()
    {
        // Arrange
        BankAccount account = new BankAccount("1234567890");
        account.Deposit(100);
        decimal initialBalance = account.Balance;
        decimal invalidWithdrawalAmount = -50;

        // Act
        account.Withdraw(invalidWithdrawalAmount);
        decimal newBalance = account.Balance;

        // Assert
        Assert.Equal(initialBalance, newBalance);
    }
}
