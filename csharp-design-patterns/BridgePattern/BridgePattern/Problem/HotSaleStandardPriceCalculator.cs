namespace BridgePattern.Problem;

public class HotSaleStandardPriceCalculator : StandardPriceCalculator
{
    protected override decimal GetDiscount(decimal price)
    {
        return price > 50 ? 20 : 0;
    }
}