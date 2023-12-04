using HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Processors;

public class BarcodeFulfillmentProcessor : IFulfillBarcodeTickets
{
    public string Fulfill(string requestId) =>  $"{requestId} | Fulfilling tickets using barcode delivery method";
}