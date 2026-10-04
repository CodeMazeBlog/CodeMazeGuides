namespace Banking.Domain;

public static class AccountErrors
{
    public static Error NotFound(int accountId) =>
        new("Account.NotFound", $"Account {accountId} was not found.", ErrorType.NotFound);

    public static Error InsufficientFunds(decimal balance, decimal requested) =>
        new("Account.InsufficientFunds", $"The balance is {balance:0.00}, {requested:0.00} requested.", ErrorType.Conflict);
}
