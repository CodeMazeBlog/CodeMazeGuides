using BridgePattern.Solution.Discounts;

namespace BridgePattern.Solution.Calculators;

public class ExpeditedPriceCalculator(IDiscount discountScheme) : PriceCalculator(discountScheme)
{
    protected override decimal GetDeliveryFee() => 5m;
}