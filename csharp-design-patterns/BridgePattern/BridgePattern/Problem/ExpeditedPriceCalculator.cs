namespace BridgePattern.Problem;

public class ExpeditedPriceCalculator : PriceCalculator
{
    protected override decimal GetDeliveryFee() => 5m;

    protected override decimal GetDiscount(decimal price) => 0;
}