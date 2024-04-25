namespace HttpClientDelegatingHandlersInAspNetCore.Services.Concrete;

using Services.Abstract;
using System.Diagnostics;

public class MetricsProvider : IMetricsProvider
{
    private readonly ILogger<MetricsProvider> _logger;
    private Stopwatch _stopwatch;
    private string _uriPath;

    public MetricsProvider(ILogger<MetricsProvider> logger)
    {
        _logger = logger;
    }

    public IDisposable MeasureTime(string uriPath)
    {
        _uriPath = uriPath;

        _stopwatch = new();
        _stopwatch.Start();

        return this;
    }

    void IDisposable.Dispose()
    {
        _stopwatch.Stop();

        _logger.LogInformation("Request duration for {uriPath}: {elapsedMs}ms", _uriPath, _stopwatch.ElapsedMilliseconds);
    }
}