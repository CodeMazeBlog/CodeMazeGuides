namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

public class TransientIdentifiableHandler(ILogger<TransientIdentifiableHandler> logger) : DelegatingHandler
{
    private readonly Guid _id = Guid.NewGuid();

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Request made from handler with Id: {id}", _id);

        return await base.SendAsync(request, cancellationToken);
    }
}