using EventTicketing.Domain;

namespace EventTicketing.Application;

public interface IEventRepository
{
    Task<Event?> GetByIdAsync(int eventId, CancellationToken cancellationToken = default);

    Task<EventAvailability?> GetAvailabilityAsync(int eventId, CancellationToken cancellationToken = default);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
