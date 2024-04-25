namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

using Services.Abstract;

public class MetricsHandler(IMetricsProvider metricsProvider, ILogger<MetricsHandler> logger)
    : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Hello from MetricsHandler");

        HttpResponseMessage response = null;

        using (var metrics = metricsProvider.MeasureTime(request.RequestUri.AbsoluteUri))
        {
            response = await base.SendAsync(request, cancellationToken);
        }

        logger.LogInformation("Goodbye from MetricsHandler");

        return response;
    }
}