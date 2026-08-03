using RegisterInstancesOfInterface.Api.Redesign.Interfaces;

namespace RegisterInstancesOfInterface.Api.Redesign.Processors;

public class PostalFulfillmentProcessor : IFulfillPostalTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using postal delivery method";
}