
namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

public class SimpleHandler(ILogger<SimpleHandler> logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Hello from SimpleHandler");

        var response = await base.SendAsync(request, cancellationToken);

        logger.LogInformation("Goodbye from SimpleHandler");

        return response;
    }
}