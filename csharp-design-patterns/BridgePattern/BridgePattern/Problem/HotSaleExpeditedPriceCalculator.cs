namespace BridgePattern.Problem;

public class HotSaleExpeditedPriceCalculator : ExpeditedPriceCalculator
{
    protected override decimal GetDiscount(decimal price)
    {
        return price > 50 ? 20 : 0;
    }
}