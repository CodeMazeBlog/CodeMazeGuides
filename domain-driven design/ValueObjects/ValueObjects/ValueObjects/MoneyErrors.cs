namespace ValueObjects.ValueObjects;

public static class MoneyErrors
{
    public static Error NegativeAmount(decimal amount) =>
        new("Money.NegativeAmount", $"Amount {amount} is negative.", ErrorType.Validation);

    public static Error UnsupportedCurrency(string currency) =>
        new("Money.UnsupportedCurrency", $"Currency '{currency}' is not supported.", ErrorType.Validation);
}
