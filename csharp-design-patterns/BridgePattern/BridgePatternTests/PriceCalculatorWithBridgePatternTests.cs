using BridgePattern;
using BridgePattern.Solution.Calculators;
using BridgePattern.Solution.Discounts;

namespace BridgePatternTests;

public class PriceCalculatorWithBridgePatternTests
{
    [Fact]
    public void WhenUsingBridgePattern_ThenEachCalculatorClass_CanWorkWith_EveryDiscountModel()
    {
        var productPrice = 100m;

        var standard = new StandardPriceCalculator(new NoDiscount())
            .Calculate(productPrice);
        Console.WriteLine($"Standard: {standard}"); // 102.5

        var standardPromo = new StandardPriceCalculator(new PromoCodeDiscount(PromoCode.Free10))
            .Calculate(productPrice);
        Console.WriteLine($"Standard Promo: {standardPromo}"); // 92.5

        var standardHotSale = new StandardPriceCalculator(new HotSaleDiscount())
            .Calculate(productPrice);
        Console.WriteLine($"Standard HotSale: {standardHotSale}"); // 82.5

        Assert.Equal(102.5m, standard);
        Assert.Equal(92.5m, standardPromo);
        Assert.Equal(82.5m, standardHotSale);
    }
}