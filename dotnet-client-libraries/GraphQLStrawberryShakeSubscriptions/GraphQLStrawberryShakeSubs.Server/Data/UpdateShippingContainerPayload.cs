namespace GraphQLStrawberryShakeSubs.Server.Data;

public class UpdateShippingContainerPayload(ShippingContainer shippingContainer)
{
    public ShippingContainer ShippingContainer { get; } = shippingContainer;
}
