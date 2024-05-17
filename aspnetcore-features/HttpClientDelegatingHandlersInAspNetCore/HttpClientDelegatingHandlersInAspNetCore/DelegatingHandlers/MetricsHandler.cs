namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

using System.Diagnostics;

public class MetricsHandler(ILogger<MetricsHandler> logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Hello from MetricsHandler");

        var stopwatch = Stopwatch.StartNew();

        var response = await base.SendAsync(request, cancellationToken);

        stopwatch.Stop();

        logger.LogInformation("Request duration for {uriPath}: {elapsedMs}ms", 
            request.RequestUri.AbsoluteUri, stopwatch.ElapsedMilliseconds);

        logger.LogInformation("Goodbye from MetricsHandler");

        return response;
    }
}