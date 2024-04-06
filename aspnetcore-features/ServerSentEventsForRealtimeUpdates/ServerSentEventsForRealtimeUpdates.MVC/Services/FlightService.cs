using ServerSentEventsForRealtimeUpdates.MVC.Models.Flight;

namespace ServerSentEventsForRealtimeUpdates.MVC.Services;

public class FlightService(IFlight flight) : IFlightService
{
    public async Task<string> GetFlightsInformation()
    {
        await Task.Delay(3500);
        return flight
                .GetFlight()
                .PrintFlight();
    }
}