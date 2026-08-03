using BridgePattern.Solution.Discounts;

namespace BridgePattern.Solution.Calculators;

public abstract class PriceCalculator(IDiscount discount)
{
    public decimal Calculate(decimal basePrice)
    {
        var deliveryFee = GetDeliveryFee();

        var discountAmount = discount.GetDiscount(basePrice);

        return basePrice + deliveryFee - discountAmount;
    }

    protected abstract decimal GetDeliveryFee();
}