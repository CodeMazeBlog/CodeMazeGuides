using EventTicketing.Data;
using EventTicketing.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventTicketing.Features.Events;

public static class GetEventAvailability
{
    public sealed record Response(int EventId, string Name, int TicketsLeft);

    public sealed class Handler(TicketingDbContext dbContext)
    {
        public async Task<Result<Response>> HandleAsync(
            int eventId, CancellationToken cancellationToken = default)
        {
            var availability = await dbContext.Events
                .AsNoTracking()
                .Where(e => e.Id == eventId)
                .Select(e => new Response(e.Id, e.Name, e.Capacity - e.TicketsSold))
                .FirstOrDefaultAsync(cancellationToken);

            if (availability is null)
                return EventErrors.NotFound(eventId);

            return availability;
        }
    }

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/{eventId:int}", async (
            int eventId,
            Handler handler,
            CancellationToken cancellationToken) =>
        {
            var result = await handler.HandleAsync(eventId, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });
}
