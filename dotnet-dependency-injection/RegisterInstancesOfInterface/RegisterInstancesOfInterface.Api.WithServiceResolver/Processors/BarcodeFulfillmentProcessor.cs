using RegisterInstancesOfInterface.Api.WithServiceResolver.Interfaces;

namespace RegisterInstancesOfInterface.Api.WithServiceResolver.Processors;

public class BarcodeFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using barcode delivery method";
}