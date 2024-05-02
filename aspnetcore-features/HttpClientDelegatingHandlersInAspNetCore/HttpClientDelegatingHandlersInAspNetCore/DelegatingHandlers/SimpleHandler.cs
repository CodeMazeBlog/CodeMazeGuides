namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

public class SimpleHandler(ILogger<SimpleHandler> Logger) : DelegatingHandler
{
    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Hello from SimpleHandler");

        var response = base.Send(request, cancellationToken);

        Logger.LogInformation("Goodbye from SimpleHandler");

        return response;
    }
}