namespace EventTicketing.Application.Events;

public interface IEventReadRepository
{
    Task<EventAvailabilityResponse?> GetAvailabilityAsync(
        int eventId, CancellationToken cancellationToken = default);
}
