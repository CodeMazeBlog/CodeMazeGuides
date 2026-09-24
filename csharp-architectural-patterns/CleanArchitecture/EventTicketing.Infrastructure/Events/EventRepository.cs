using EventTicketing.Application.Events;
using EventTicketing.Domain.Events;
using EventTicketing.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventTicketing.Infrastructure.Events;

public sealed class EventRepository(TicketingDbContext dbContext) : IEventRepository
{
    public Task<Event?> GetByIdAsync(int eventId, CancellationToken cancellationToken = default) =>
        dbContext.Events.FirstOrDefaultAsync(e => e.Id == eventId, cancellationToken);
}
