public class BankAccountTests
{
    [Fact]
    public void GivenValidDepositAmount_WhenDepositCalled_ThenBalanceIncreased()
    {
        // Arrange
        decimal initialBalance = 500;
        BankAccount account = new BankAccount("12345", initialBalance);
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
        decimal initialBalance = 500; 
        BankAccount account = new BankAccount("12345", initialBalance);
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
        decimal initialBalance = 200; 
        BankAccount account = new BankAccount("12345", initialBalance);
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
        decimal initialBalance = 100;
        BankAccount account = new BankAccount("12345", initialBalance);
        decimal invalidWithdrawalAmount = -50;

        // Act
        account.Withdraw(invalidWithdrawalAmount);
        decimal newBalance = account.Balance;

        // Assert
        Assert.Equal(initialBalance, newBalance);
    }
}