using EventTicketing.Api.Contracts;
using EventTicketing.Api.Extensions;
using EventTicketing.Application.Events;

namespace EventTicketing.Api.Endpoints;

public static class EventEndpoints
{
    public static IEndpointRouteBuilder MapEventEndpoints(this IEndpointRouteBuilder app)
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

        return app;
    }
}
