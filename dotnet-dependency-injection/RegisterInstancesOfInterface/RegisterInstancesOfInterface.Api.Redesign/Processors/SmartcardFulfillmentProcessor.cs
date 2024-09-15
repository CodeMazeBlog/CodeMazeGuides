using RegisterInstancesOfInterface.Api.Redesign.Interfaces;

namespace RegisterInstancesOfInterface.Api.Redesign.Processors;

public class SmartcardFulfillmentProcessor : IFulfillSmartcardTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using smartcard delivery method";
}