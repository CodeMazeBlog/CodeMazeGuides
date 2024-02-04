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

        if (timeToDeparture >= 2)
        {
            return string.Format(Messages.FlightDepartsInMoreThanTwoHours, flight.From, flight.To);
        }
        else if (timeToDeparture <= 2 && timeToDeparture > 1)
        {
            return string.Format(Messages.FlightDepartsInLessThanTwoHours, flight.From, flight.To);
        }
        else if (timeToDeparture <= 1 && timeToDeparture > 0.5)
        {
            return string.Format(Messages.FlightDepartsInLessThanOneHour, flight.From, flight.To);
        }
        else if (timeToDeparture <= 0.5 && timeToDeparture > 0)
        {
            return string.Format(Messages.FlightDepartsInLessThanThirtyMinutes, flight.From, flight.To);
        }
        else
        {
            return string.Format(Messages.FlightAlreadyDeparted, flight.From, flight.To);
        }
    }
}
