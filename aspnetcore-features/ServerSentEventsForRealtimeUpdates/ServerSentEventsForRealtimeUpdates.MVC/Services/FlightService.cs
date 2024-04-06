using ServerSentEventsForRealtimeUpdates.MVC.Models.Flight;

namespace ServerSentEventsForRealtimeUpdates.MVC.Services;

public class FlightService : IFlightService
{
    public async Task<string> GetFlightsInformation()
    {
        await Task.Delay(3500);
        
        IFlight flight = new Flight();
        return flight
                .GetFlight()
                .PrintFlight();
    }
}