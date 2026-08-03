using OverwriteDateTimeDuringTesting.Data;

namespace OverwriteDateTimeDuringTesting.Abstractions;

public interface IFlightNotificationService
{
    string GetFlightNotificationMessage(Flight flight);
}
