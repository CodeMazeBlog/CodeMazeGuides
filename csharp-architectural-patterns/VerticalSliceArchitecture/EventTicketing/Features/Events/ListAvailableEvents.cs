using EventTicketing.Data;
using Microsoft.EntityFrameworkCore;

namespace EventTicketing.Features.Events;

public static class ListAvailableEvents
{
    public sealed record AvailableEvent(int EventId, string Name, int TicketsLeft);

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/", async (TicketingDbContext dbContext, CancellationToken cancellationToken) =>
            await dbContext.Events
                .AsNoTracking()
                .Where(e => e.TicketsSold < e.Capacity)
                .Select(e => new AvailableEvent(e.Id, e.Name, e.Capacity - e.TicketsSold))
                .ToListAsync(cancellationToken));
}
