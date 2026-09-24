using EventTicketing.Application.Abstractions;
using EventTicketing.Application.Events;
using EventTicketing.Domain.Events;

namespace EventTicketing.UnitTests.Application;

internal sealed class FakeEventRepository(Event? ev) : IEventRepository
{
    public Task<Event?> GetByIdAsync(int eventId, CancellationToken cancellationToken = default) =>
        Task.FromResult(ev);
}

internal sealed class FakeUnitOfWork : IUnitOfWork
{
    public int SaveCount { get; private set; }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SaveCount++;
        return Task.CompletedTask;
    }
}
