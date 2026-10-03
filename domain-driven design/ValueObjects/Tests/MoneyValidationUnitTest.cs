using ValueObjects.ValueObjects;

namespace Tests;

public class MoneyValidationUnitTest
{
    [Fact]
    public void GivenANegativeAmount_WhenCreatingMoney_ThenItFails()
    {
        var result = Money.Create(-5, "USD");

        Assert.False(result.IsSuccess);
        Assert.Equal("Money.NegativeAmount", result.Error!.Code);
    }

    [Fact]
    public void GivenAnUnsupportedCurrency_WhenCreatingMoney_ThenItFails()
    {
        var result = Money.Create(100, "GBP");

        Assert.False(result.IsSuccess);
        Assert.Equal("Money.UnsupportedCurrency", result.Error!.Code);
    }

    [Fact]
    public void GivenALowerCaseCurrency_WhenCreatingMoney_ThenItEqualsTheUpperCaseOne()
    {
        var typed = Money.Create(100, "usd").Value;

        Assert.Equal("USD", typed.Currency);
        Assert.Equal(Money.Create(100, "USD").Value, typed);
    }
}
