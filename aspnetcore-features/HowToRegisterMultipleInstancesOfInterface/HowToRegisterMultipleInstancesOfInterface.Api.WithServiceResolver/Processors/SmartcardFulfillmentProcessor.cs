using HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Processors;

public class SmartcardFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using smartcard delivery method";
}