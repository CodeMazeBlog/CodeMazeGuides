namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

public class TransientIdentifiableHandler(ILogger<TransientIdentifiableHandler> Logger) : DelegatingHandler
{
    private readonly Guid _id = Guid.NewGuid();

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Request made from handler with Id: {id}", _id);

        return await base.SendAsync(request, cancellationToken);
    }
}