using BridgePattern.Solution.Discounts;

namespace BridgePattern.Solution.Calculators;

public class StandardPriceCalculator(IDiscount discount) : PriceCalculator(discount)
{
    protected override decimal GetDeliveryFee() => 2.5m;
}