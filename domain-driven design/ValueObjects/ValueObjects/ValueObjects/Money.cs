namespace ValueObjects.ValueObjects;

public sealed record Money
{
    private static readonly string[] SupportedCurrencies = ["USD", "EUR"];

    public decimal Amount { get; }
    public string Currency { get; }

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Result<Money> Create(decimal amount, string currency)
    {
        if (amount < 0)
            return MoneyErrors.NegativeAmount(amount);

        var code = currency.ToUpperInvariant();

        if (!SupportedCurrencies.Contains(code))
            return MoneyErrors.UnsupportedCurrency(currency);

        return new Money(amount, code);
    }
}
