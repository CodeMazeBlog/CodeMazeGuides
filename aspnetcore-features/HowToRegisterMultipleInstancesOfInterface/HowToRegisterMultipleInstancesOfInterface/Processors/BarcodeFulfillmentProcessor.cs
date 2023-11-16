using HowToRegisterMultipleInstancesOfInterface.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Implementations;

public class BarcodeFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId)
    {
        return $"{requestId} | Fulfilling tickets using barcode delivery method";
    }
}