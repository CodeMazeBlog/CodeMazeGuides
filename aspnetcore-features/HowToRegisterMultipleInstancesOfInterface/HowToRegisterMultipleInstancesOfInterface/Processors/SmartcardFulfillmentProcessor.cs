using HowToRegisterMultipleInstancesOfInterface.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Implementations;

public class SmartcardFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId)
    {
        return $"{requestId} | Fulfilling tickets using smartcard delivery method";
    }
}