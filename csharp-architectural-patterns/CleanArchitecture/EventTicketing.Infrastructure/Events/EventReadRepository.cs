using EventTicketing.Application.Events;
using EventTicketing.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventTicketing.Infrastructure.Events;

public sealed class EventReadRepository(TicketingDbContext dbContext) : IEventReadRepository
{
    public Task<EventAvailabilityResponse?> GetAvailabilityAsync(
        int eventId, CancellationToken cancellationToken = default) =>
        dbContext.Events
            .AsNoTracking()
            .Where(e => e.Id == eventId)
            .Select(e => new EventAvailabilityResponse(
                e.Id, e.Name, e.Capacity, e.Capacity - e.TicketsSold))
            .FirstOrDefaultAsync(cancellationToken);
}
