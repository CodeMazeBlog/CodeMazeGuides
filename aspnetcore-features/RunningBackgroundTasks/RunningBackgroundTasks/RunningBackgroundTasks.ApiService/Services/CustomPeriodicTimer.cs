using RunningBackgroundTasks.ApiService.Services.Abstractions;

namespace RunningBackgroundTasks.ApiService.Services;

public sealed class CustomPeriodicTimer : IPeriodicTimer
{
    private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(5));

    public async ValueTask<bool> WaitForNextTickAsync(CancellationToken cancellationToken = default)
        => await _timer.WaitForNextTickAsync(cancellationToken);

    public void Dispose() => _timer.Dispose();
}
