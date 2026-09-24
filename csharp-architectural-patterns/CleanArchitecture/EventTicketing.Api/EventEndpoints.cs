using System.ComponentModel.DataAnnotations;
using EventTicketing.Application;

namespace EventTicketing.Api;

public sealed record ReserveTicketsRequest([property: Range(1, 20)] int Quantity);

public static class EventEndpoints
{
    public static void MapEventEndpoints(this IEndpointRouteBuilder app)
    {
        var events = app.MapGroup("/api/events");

        events.MapGet("/{eventId:int}", async (
            int eventId,
            GetEventAvailabilityHandler handler,
            CancellationToken cancellationToken) =>
        {
            var result = await handler.HandleAsync(new GetEventAvailabilityQuery(eventId), cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });

        events.MapPost("/{eventId:int}/reservations", async (
            int eventId,
            ReserveTicketsRequest request,
            ReserveTicketsHandler handler,
            CancellationToken cancellationToken) =>
        {
            var command = new ReserveTicketsCommand(eventId, request.Quantity);
            var result = await handler.HandleAsync(command, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });
    }
}
