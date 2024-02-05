using OverwriteDateTimeDuringTesting.Abstractions;
using OverwriteDateTimeDuringTesting.Constants;
using OverwriteDateTimeDuringTesting.Data;

namespace OverwriteDateTimeDuringTesting;

public class FlightNotificationService(TimeProvider timeProvider) : IFlightNotificationService
{
    public string GetFlightNotificationMessage(Flight flight)
    {
        var now = timeProvider.GetUtcNow().ToLocalTime();
        var timeToDeparture = (flight.Time - now).TotalHours;

        return timeToDeparture switch
        {
            var x when x >= 2 
                => string.Format(Messages.FlightDepartsInMoreThanTwoHours, flight.From, flight.To),
            var x when x <= 2 && x > 1 
                => string.Format(Messages.FlightDepartsInLessThanTwoHours, flight.From, flight.To),
            var x when x <= 1 && x > 0.5 
                => string.Format(Messages.FlightDepartsInLessThanOneHour, flight.From, flight.To),
            var x when x <= 0.5 && x > 0 
                => string.Format(Messages.FlightDepartsInLessThanThirtyMinutes, flight.From, flight.To),
            _ => string.Format(Messages.FlightAlreadyDeparted, flight.From, flight.To)
        };
    }
}
