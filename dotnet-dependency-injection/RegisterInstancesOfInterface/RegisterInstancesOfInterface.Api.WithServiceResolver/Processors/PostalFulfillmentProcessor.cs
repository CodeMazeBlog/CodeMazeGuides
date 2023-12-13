using RegisterInstancesOfInterface.Api.WithServiceResolver.Interfaces;

namespace RegisterInstancesOfInterface.Api.WithServiceResolver.Processors;

public class PostalFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using postal delivery method";
}