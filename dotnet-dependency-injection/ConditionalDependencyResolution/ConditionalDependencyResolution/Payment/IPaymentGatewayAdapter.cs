namespace ConditionalDependencyResolution.Payment;

public interface IPaymentGatewayAdapter
{
    string Pay(GatewayType type, decimal amount);
}