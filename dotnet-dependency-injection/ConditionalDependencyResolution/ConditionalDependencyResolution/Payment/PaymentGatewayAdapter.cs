namespace ConditionalDependencyResolution.Payment;

public class PaymentGatewayAdapter : IPaymentGatewayAdapter
{
    private readonly GatewayOne _gatewayOne;
    private readonly GatewayTwo _gatewayTwo;

    public PaymentGatewayAdapter(
        GatewayOne gatewayOne,
        GatewayTwo gatewayTwo)
    {
        _gatewayOne = gatewayOne;
        _gatewayTwo = gatewayTwo;
    }

    public string Pay(GatewayType type, decimal amount)
    {
        return type switch
        {
            GatewayType.One => _gatewayOne.Pay(amount, "USD"),
            GatewayType.Two => _gatewayTwo.SendPayment(amount),
            _ => throw new NotImplementedException(),
        };
    }
}