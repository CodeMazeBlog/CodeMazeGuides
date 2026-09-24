using EventTicketing.Domain.Common;

namespace EventTicketing.Domain.Events;

public static class EventErrors
{
    public static Error NotFound(int eventId) =>
        Error.NotFound("Event.NotFound", $"Event {eventId} was not found.");

    public static Error SoldOut(int ticketsLeft, int requested) =>
        Error.Conflict("Event.SoldOut", $"Only {ticketsLeft} tickets left, {requested} requested.");
}
