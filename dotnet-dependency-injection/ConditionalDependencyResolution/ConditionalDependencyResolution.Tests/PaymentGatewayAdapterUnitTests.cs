using ConditionalDependencyResolution.Payment;

namespace ConditionalDependencyResolution.Tests;

public class PaymentGatewayAdapterUnitTests : BaseUnitTest
{
    [Fact]
    public void GivenMultipleGateways_WhenUsingAdapterClass_ThenCanBeUtilizedInterchangeably()
    {
        var adapter = _serviceProvider.GetService<IPaymentGatewayAdapter>()!;

        Assert.Equal("GatewayOne: Paid 20 USD", adapter.Pay(GatewayType.One, 20));
        Assert.Equal("GatewayTwo: Paid 20 USD", adapter.Pay(GatewayType.Two, 20));
    }
}