namespace BridgePattern.Problem;

public class HotSaleExpressPriceCalculator : ExpressPriceCalculator
{
    protected override decimal GetDiscount(decimal price)
    {
        return price > 50 ? 20 : 0;
    }
}