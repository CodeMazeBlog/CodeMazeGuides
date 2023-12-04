using HowToRegisterMultipleInstancesOfInterface.Api.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Processors;

public class PostalFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using postal delivery method";
}