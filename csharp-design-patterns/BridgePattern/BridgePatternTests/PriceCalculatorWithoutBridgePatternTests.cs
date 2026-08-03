using BridgePattern;
using BridgePattern.Problem;

namespace BridgePatternTests;

public class PriceCalculatorWithoutBridgePatternTests
{
    [Fact]
    public void WhenNotUsingBridgePattern_ThenEachCalculatorClass_ServesASpecificDiscountModel()
    {
        var productPrice = 100m;

        var standard = new StandardPriceCalculator()
            .Calculate(productPrice);
        Console.WriteLine($"Standard: {standard}"); // 102.5

        var standardPromo = new PromoCodeStandardPriceCalculator(PromoCode.Free10)
            .Calculate(productPrice);
        Console.WriteLine($"Standard Promo: {standardPromo}"); // 92.5

        var standardHotSale = new HotSaleStandardPriceCalculator()
            .Calculate(productPrice);
        Console.WriteLine($"Standard HotSale: {standardHotSale}"); // 82.5

        Assert.Equal(102.5m, standard);
        Assert.Equal(92.5m, standardPromo);
        Assert.Equal(82.5m, standardHotSale);
    }
}