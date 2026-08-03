namespace BridgePattern.Problem;

public class ExpressPriceCalculator : PriceCalculator
{
    protected override decimal GetDeliveryFee() => 8m;

    protected override decimal GetDiscount(decimal price) => 0;
}