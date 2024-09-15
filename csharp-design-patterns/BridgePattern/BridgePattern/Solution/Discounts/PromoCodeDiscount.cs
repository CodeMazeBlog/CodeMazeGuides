namespace BridgePattern.Solution.Discounts;

public class PromoCodeDiscount(PromoCode promoCode) : IDiscount
{
    public decimal GetDiscount(decimal price)
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