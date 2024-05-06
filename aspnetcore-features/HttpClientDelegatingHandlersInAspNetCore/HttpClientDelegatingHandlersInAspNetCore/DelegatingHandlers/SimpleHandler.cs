
namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

public class SimpleHandler(ILogger<SimpleHandler> Logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Hello from SimpleHandler");

        var response = await base.SendAsync(request, cancellationToken);

        Logger.LogInformation("Goodbye from SimpleHandler");

        return response;
    }
}