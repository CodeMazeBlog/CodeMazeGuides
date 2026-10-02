namespace Banking.Domain;

public sealed class Account
{
    private Account(string owner, decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }

    public int Id { get; private set; }
    public string Owner { get; private set; }
    public decimal Balance { get; private set; }

    public static Account Open(string owner, decimal balance)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(owner);
        ArgumentOutOfRangeException.ThrowIfNegative(balance);

        return new Account(owner, balance);
    }

    public Result Withdraw(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        if (amount > Balance)
            return AccountErrors.InsufficientFunds(Balance, amount);

        Balance -= amount;

        return Result.Success();
    }

    public void Deposit(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        Balance += amount;
    }
}
