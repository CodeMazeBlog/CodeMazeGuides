namespace HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

using Services.Abstract;
using System.Net.Http.Headers;

public class AuthorizationHandler(ITokenGenerator tokenGenerator, ILogger<AuthorizationHandler> logger) 
    : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Hello from AuthorizationHandler");

        var token = tokenGenerator.GenerateToken();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await base.SendAsync(request, cancellationToken);

        logger.LogInformation("Goodbye from AuthorizationHandler");

        return response;
    }
}