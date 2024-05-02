namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

public class SimpleHandler(ILogger<SimpleHandler> logger) : DelegatingHandler
{
    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Hello from SimpleHandler");

        var response = base.Send(request, cancellationToken);

        logger.LogInformation("Goodbye from SimpleHandler");

        return response;
    }
}