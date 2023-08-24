namespace ConditionalDependencyResolution.Pricing;

public interface IPricingService
{
    decimal Calculate(decimal basePrice, int quantity);
}