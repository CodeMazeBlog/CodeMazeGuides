using System.ComponentModel.DataAnnotations;
using EventTicketing.Data;
using EventTicketing.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventTicketing.Features.Reservations;

public static class ReserveTickets
{
    public sealed record Request([property: Range(1, 20)] int Quantity);

    public sealed record Response(int EventId, int TicketsReserved, int TicketsLeft);

    public sealed class Handler(TicketingDbContext dbContext)
    {
        public async Task<Result<Response>> HandleAsync(
            int eventId, int quantity, CancellationToken cancellationToken = default)
        {
            var ev = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == eventId, cancellationToken);
            if (ev is null)
                return EventErrors.NotFound(eventId);

            var reservation = ev.Reserve(quantity);
            if (!reservation.IsSuccess)
                return reservation.Error!;

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response(ev.Id, quantity, ev.TicketsLeft);
        }
    }

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/{eventId:int}/reservations", async (
            int eventId,
            Request request,
            Handler handler,
            CancellationToken cancellationToken) =>
        {
            var result = await handler.HandleAsync(eventId, request.Quantity, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });
}
