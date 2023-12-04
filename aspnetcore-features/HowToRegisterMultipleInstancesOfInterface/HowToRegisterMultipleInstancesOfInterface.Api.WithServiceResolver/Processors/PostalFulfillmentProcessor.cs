using HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Processors;

public class PostalFulfillmentProcessor : IFulfillTickets
{
    public string Fulfill(string requestId) => $"{requestId} | Fulfilling tickets using postal delivery method";
}