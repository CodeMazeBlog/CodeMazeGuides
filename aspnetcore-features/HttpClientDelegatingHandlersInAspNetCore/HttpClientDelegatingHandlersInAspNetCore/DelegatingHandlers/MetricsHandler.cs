namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

using System.Diagnostics;

public class MetricsHandler(ILogger<MetricsHandler> Logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Hello from MetricsHandler");

        var stopwatch = Stopwatch.StartNew();

        var response = await base.SendAsync(request, cancellationToken);

        stopwatch.Stop();

        Logger.LogInformation("Request duration for {uriPath}: {elapsedMs}ms", request.RequestUri.AbsoluteUri, stopwatch.ElapsedMilliseconds);
        Logger.LogInformation("Goodbye from MetricsHandler");

        return response;
    }
}