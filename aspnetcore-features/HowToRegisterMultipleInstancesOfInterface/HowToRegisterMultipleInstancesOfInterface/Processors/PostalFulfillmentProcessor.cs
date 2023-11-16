using HowToRegisterMultipleInstancesOfInterface.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Implementations;

public class PostalFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId)
    {
        return $"{requestId} | Fulfilling tickets using postal delivery method";
    }
}