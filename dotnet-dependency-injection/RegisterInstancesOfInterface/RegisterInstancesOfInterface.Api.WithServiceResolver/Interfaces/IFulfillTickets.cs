namespace RegisterInstancesOfInterface.Api.WithServiceResolver.Interfaces;

public interface IFulfillTickets
{
    string Fulfill(string requestId);
}