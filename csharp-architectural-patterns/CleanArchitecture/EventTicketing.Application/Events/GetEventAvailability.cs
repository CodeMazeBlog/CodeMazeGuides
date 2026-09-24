using EventTicketing.Domain.Common;
using EventTicketing.Domain.Events;

namespace EventTicketing.Application.Events;

public sealed record GetEventAvailabilityQuery(int EventId);

public sealed record EventAvailabilityResponse(int EventId, string Name, int Capacity, int TicketsLeft);

public sealed class GetEventAvailabilityHandler(IEventReadRepository reads)
{
    public async Task<Result<EventAvailabilityResponse>> HandleAsync(
        GetEventAvailabilityQuery query, CancellationToken cancellationToken = default)
    {
        var availability = await reads.GetAvailabilityAsync(query.EventId, cancellationToken);
        if (availability is null)
            return EventErrors.NotFound(query.EventId);

        return availability;
    }
}
