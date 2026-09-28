using EventTicketing.Application;
using EventTicketing.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventTicketing.Infrastructure;

public sealed class EventRepository(TicketingDbContext dbContext) : IEventRepository
{
    public Task<Event?> GetByIdAsync(int eventId, CancellationToken cancellationToken = default) =>
        dbContext.Events.FirstOrDefaultAsync(e => e.Id == eventId, cancellationToken);

    public Task<EventAvailability?> GetAvailabilityAsync(int eventId, CancellationToken cancellationToken = default) =>
        dbContext.Events
            .AsNoTracking()
            .Where(e => e.Id == eventId)
            .Select(e => new EventAvailability(e.Id, e.Name, e.Capacity - e.TicketsSold))
            .FirstOrDefaultAsync(cancellationToken);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
