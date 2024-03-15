using RunningBackgroundTasks.Services.Abstractions;

namespace RunningBackgroundTasks.Services;

public sealed class DailyPeriodicTimer : IPeriodicTimer
{
    private readonly PeriodicTimer _timer = new(TimeSpan.FromHours(24));

    public async ValueTask<bool> WaitForNextTickAsync(CancellationToken cancellationToken = default)
        => await _timer.WaitForNextTickAsync(cancellationToken);

    public void Dispose() => _timer.Dispose();
}
