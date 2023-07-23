namespace ValueObjects.ValueObjects;

public record Money
{
    private static readonly IReadOnlyCollection<string> SupportedCurrencies = new[]{"USD", "EUR"};

    public decimal Amount { get; }
    public string Currency { get; }
    
    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Result<Money> Create(decimal amount, string currency)
    {
        if(string.IsNullOrWhiteSpace(currency))
            return Result<Money>.Failure($"{nameof(currency)} cannot be null or whitespace.");

        if(!SupportedCurrencies.Contains(currency.ToUpperInvariant()))
            return Result<Money>.Failure($"'{currency}' is not supported.");
        
        return Result<Money>.Success(new(amount, currency));
    }
}