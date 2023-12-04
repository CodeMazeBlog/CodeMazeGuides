using HowToRegisterMultipleInstancesOfInterface.Api.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Processors;

public class SmartcardFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using smartcard delivery method";
}