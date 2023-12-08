using RegisterInstancesOfInterface.Api.Redesign.Interfaces;

namespace RegisterInstancesOfInterface.Api.Redesign.Processors;

public class BarcodeFulfillmentProcessor : IFulfillBarcodeTickets
{
    public string Fulfill(string requestId) =>  $"{requestId} | Fulfilling tickets using barcode delivery method";
}