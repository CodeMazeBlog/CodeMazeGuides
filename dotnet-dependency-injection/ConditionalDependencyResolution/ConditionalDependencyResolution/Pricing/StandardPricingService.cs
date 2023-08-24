namespace ConditionalDependencyResolution.Pricing;

public class StandardPricingService : IPricingService
{
    public decimal Calculate(decimal basePrice, int quantity)
    {
        return basePrice * quantity;
    }
}