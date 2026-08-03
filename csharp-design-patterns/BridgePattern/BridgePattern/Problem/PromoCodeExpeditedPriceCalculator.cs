namespace BridgePattern.Problem;

public class PromoCodeExpeditedPriceCalculator(PromoCode promoCode) : ExpeditedPriceCalculator
{
    protected override decimal GetDiscount(decimal price)
    {
        var factor = promoCode switch
        {
            PromoCode.Free5 => 0.05m,
            PromoCode.Free10 => 0.10m,
            _ => throw new NotImplementedException()
        };

        return price * factor;
    }
}