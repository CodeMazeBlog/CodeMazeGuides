namespace BridgePattern.Problem;

public class StandardPriceCalculator : PriceCalculator
{
    protected override decimal GetDeliveryFee() => 2.5m;

    protected override decimal GetDiscount(decimal price) => 0;
}