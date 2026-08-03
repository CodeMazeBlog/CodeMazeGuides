namespace BridgePattern.Problem;

public abstract class PriceCalculator
{
    public decimal Calculate(decimal basePrice)
    {
        var deliveryFee = GetDeliveryFee();

        var discount = GetDiscount(basePrice);

        return basePrice + deliveryFee - discount;
    }

    protected abstract decimal GetDeliveryFee();

    protected abstract decimal GetDiscount(decimal price);
}