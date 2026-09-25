namespace EventTicketing.Domain;

public static class EventErrors
{
    public static Error NotFound(int eventId) =>
        new("Event.NotFound", $"Event {eventId} was not found.", ErrorType.NotFound);

    public static Error SoldOut(int ticketsLeft, int requested) =>
        new("Event.SoldOut", $"Only {ticketsLeft} tickets left, {requested} requested.", ErrorType.Conflict);
}
