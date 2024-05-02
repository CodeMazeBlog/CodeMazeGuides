namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

using System.Net.Http.Headers;

public class AuthorizationHandler(ILogger<AuthorizationHandler> Logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Hello from AuthorizationHandler");

        var token = Guid.NewGuid().ToString();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await base.SendAsync(request, cancellationToken);

        Logger.LogInformation("Goodbye from AuthorizationHandler");

        return response;
    }
}