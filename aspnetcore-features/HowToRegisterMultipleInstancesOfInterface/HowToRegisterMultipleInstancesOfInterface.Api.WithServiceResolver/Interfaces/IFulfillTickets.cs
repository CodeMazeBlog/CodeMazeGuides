namespace HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Interfaces;

public interface IFulfillTickets
{
    string Fulfill(string requestId);
}