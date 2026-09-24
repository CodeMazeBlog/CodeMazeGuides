using EventTicketing.Domain.Events;

namespace EventTicketing.Application.Events;

public interface IEventRepository
{
    Task<Event?> GetByIdAsync(int eventId, CancellationToken cancellationToken = default);
}
