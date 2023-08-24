namespace ConditionalDependencyResolution.Payment;

public class GatewayOne
{
    public string Pay(decimal amount, string currencyCode)
    {
        // API logic
        return $"GatewayOne: Paid {amount} {currencyCode}";
    }
}