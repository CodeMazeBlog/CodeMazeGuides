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

    public static Account Open(string owner, decimal initialDeposit)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(owner);
        ArgumentOutOfRangeException.ThrowIfNegative(initialDeposit);

        return new Account(owner, initialDeposit);
    }

    public Result Withdraw(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        if (amount > Balance)
            return AccountErrors.InsufficientFunds(Id);

        Balance -= amount;

        return Result.Success();
    }
}
