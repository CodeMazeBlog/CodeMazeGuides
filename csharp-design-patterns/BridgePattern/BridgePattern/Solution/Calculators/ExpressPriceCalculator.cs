using BridgePattern.Solution.Discounts;

namespace BridgePattern.Solution.Calculators;

public class ExpressPriceCalculator(IDiscount discount) : PriceCalculator(discount)
{
    protected override decimal GetDeliveryFee() => 8m;
}