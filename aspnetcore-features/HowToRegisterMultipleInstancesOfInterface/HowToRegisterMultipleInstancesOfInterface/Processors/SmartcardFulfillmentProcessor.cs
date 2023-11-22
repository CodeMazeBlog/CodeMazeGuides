using HowToRegisterMultipleInstancesOfInterface.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Processors;

public class SmartcardFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using smartcard delivery method";
}