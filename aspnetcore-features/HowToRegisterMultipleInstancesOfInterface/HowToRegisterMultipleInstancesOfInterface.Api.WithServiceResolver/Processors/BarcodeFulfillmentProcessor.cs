using HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Processors;

public class BarcodeFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId) =>  $"{requestId} | Fulfilling tickets using barcode delivery method";
}