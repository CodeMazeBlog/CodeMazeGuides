namespace Banking.Domain;

public static class AccountErrors
{
    public static Error NotFound(int accountId) =>
        new("Account.NotFound", $"Account {accountId} was not found.", ErrorType.NotFound);

    public static Error InsufficientFunds(int accountId) =>
        new("Account.InsufficientFunds", $"Account {accountId} doesn't have enough money for this withdrawal.", ErrorType.Conflict);
}
