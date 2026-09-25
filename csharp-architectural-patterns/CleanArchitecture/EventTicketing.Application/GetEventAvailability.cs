using EventTicketing.Domain;

namespace EventTicketing.Application;

public sealed record GetEventAvailabilityQuery(int EventId);

public sealed record EventAvailability(int EventId, string Name, int TicketsLeft);

public sealed class GetEventAvailabilityHandler(IEventRepository events)
{
    public async Task<Result<EventAvailability>> HandleAsync(
        GetEventAvailabilityQuery query, CancellationToken cancellationToken = default)
    {
        var availability = await events.GetAvailabilityAsync(query.EventId, cancellationToken);
        if (availability is null)
            return EventErrors.NotFound(query.EventId);

        return availability;
    }
}
