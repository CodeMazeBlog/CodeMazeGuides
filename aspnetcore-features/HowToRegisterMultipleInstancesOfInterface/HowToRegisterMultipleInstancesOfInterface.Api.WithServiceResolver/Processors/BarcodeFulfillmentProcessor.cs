using HowToRegisterMultipleInstancesOfInterface.Api.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Processors;

public class BarcodeFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId) =>  $"{requestId} | Fulfilling tickets using barcode delivery method";
}