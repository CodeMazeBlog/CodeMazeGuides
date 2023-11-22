using HowToRegisterMultipleInstancesOfInterface.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Processors;

public class BarcodeFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId) =>  $"{requestId} | Fulfilling tickets using barcode delivery method";
}