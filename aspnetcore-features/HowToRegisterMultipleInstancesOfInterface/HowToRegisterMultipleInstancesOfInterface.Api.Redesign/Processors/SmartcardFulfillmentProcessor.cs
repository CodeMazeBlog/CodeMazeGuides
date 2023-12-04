using HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Processors;

public class SmartcardFulfillmentProcessor : IFulfillSmartcardTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using smartcard delivery method";
}