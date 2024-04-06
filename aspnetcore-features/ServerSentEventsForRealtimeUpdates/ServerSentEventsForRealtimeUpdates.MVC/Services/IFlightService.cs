namespace ServerSentEventsForRealtimeUpdates.MVC.Services;

public interface IFlightService
{
    Task<string> GetFlightsInformation();
}