using HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Processors;

public class PostalFulfillmentProcessor : IFulfillPostlaTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using postal delivery method";
}