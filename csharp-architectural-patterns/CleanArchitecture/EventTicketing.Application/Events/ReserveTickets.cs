using EventTicketing.Application.Abstractions;
using EventTicketing.Domain.Common;
using EventTicketing.Domain.Events;

namespace EventTicketing.Application.Events;

public sealed record ReserveTicketsCommand(int EventId, int Quantity);

public sealed record ReservationResponse(int EventId, int TicketsReserved, int TicketsLeft);

public sealed class ReserveTicketsHandler(IEventRepository events, IUnitOfWork unitOfWork)
{
    public async Task<Result<ReservationResponse>> HandleAsync(
        ReserveTicketsCommand command, CancellationToken cancellationToken = default)
    {
        var ev = await events.GetByIdAsync(command.EventId, cancellationToken);
        if (ev is null)
            return EventErrors.NotFound(command.EventId);

        var reservation = ev.Reserve(command.Quantity);
        if (reservation.IsFailure)
            return reservation.Error;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new ReservationResponse(ev.Id, command.Quantity, ev.TicketsLeft);
    }
}
