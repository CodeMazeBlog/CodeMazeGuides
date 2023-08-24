namespace ConditionalDependencyResolution.Payment;

public class GatewayTwo
{
    public string SendPayment(decimal amountInUsd)
    {
        // API logic
        return $"GatewayTwo: Paid {amountInUsd} USD";
    }
}