namespace GraphQLStrawberryShakeSubs.Server.Data;

public class AddShippingContainerPayload(ShippingContainer shippingContainer)
{
    public ShippingContainer ShippingContainer { get; } = shippingContainer;
}
