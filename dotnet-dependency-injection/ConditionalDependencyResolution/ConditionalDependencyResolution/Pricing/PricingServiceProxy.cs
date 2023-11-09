namespace ConditionalDependencyResolution.Pricing;

public class PricingServiceProxy : IPricingService
{
    private readonly StandardPricingService _standardService;
    private readonly PremiumPricingService _premiumService;

    public PricingServiceProxy(
        StandardPricingService standardService,
        PremiumPricingService premiumService) 
    {
        _standardService = standardService;
        _premiumService = premiumService;
    }

    public decimal Calculate(decimal basePrice, int quantity)
    {
        // Detect whether membership is premium or not
        var isPremium = false;

        IPricingService service = isPremium ? _premiumService : _standardService;

        return service.Calculate(basePrice, quantity);
    }
}