using EventTicketing.Domain;

namespace EventTicketing.Application;

public sealed record ReserveTicketsCommand(int EventId, int Quantity);

public sealed record ReservationResponse(int EventId, int TicketsReserved, int TicketsLeft);

public sealed class ReserveTicketsHandler(IEventRepository events)
{
    public async Task<Result<ReservationResponse>> HandleAsync(
        ReserveTicketsCommand command, CancellationToken cancellationToken = default)
    {
        var ev = await events.GetByIdAsync(command.EventId, cancellationToken);
        if (ev is null)
            return EventErrors.NotFound(command.EventId);

        var reservation = ev.Reserve(command.Quantity);
        if (!reservation.IsSuccess)
            return reservation.Error!;

        await events.SaveChangesAsync(cancellationToken);

        return new ReservationResponse(ev.Id, command.Quantity, ev.TicketsLeft);
    }
}
