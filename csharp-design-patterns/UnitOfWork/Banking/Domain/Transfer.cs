namespace Banking.Domain;

public sealed class Transfer
{
    private Transfer(int fromAccountId, int toAccountId, decimal amount, string reference)
    {
        FromAccountId = fromAccountId;
        ToAccountId = toAccountId;
        Amount = amount;
        Reference = reference;
    }

    public int Id { get; private set; }
    public int FromAccountId { get; private set; }
    public int ToAccountId { get; private set; }
    public decimal Amount { get; private set; }
    public string Reference { get; private set; }

    public static Transfer Create(Account from, Account to, decimal amount, string reference)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(reference);

        return new Transfer(from.Id, to.Id, amount, reference);
    }
}
