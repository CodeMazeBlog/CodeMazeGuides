namespace ConditionalDependencyResolution.Pricing;

public class PremiumPricingService : IPricingService
{
    public decimal Calculate(decimal basePrice, int quantity)
    {
        var discount = 0.05m;

        return basePrice * quantity * (1 - discount);
    }
}