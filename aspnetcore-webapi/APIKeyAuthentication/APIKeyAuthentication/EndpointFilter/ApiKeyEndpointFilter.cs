using APIKeyAuthentication.Interface;

namespace APIKeyAuthentication.EndpointFilter
{
    public class ApiKeyEndpointFilter : IEndpointFilter
    {
        private readonly IApiKeyValidation _apiKeyValidation;

        public ApiKeyEndpointFilter(IApiKeyValidation apiKeyValidation)
        {
            _apiKeyValidation = apiKeyValidation;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            if (string.IsNullOrWhiteSpace(context.HttpContext.Request.Headers[Constants.ApiKeyHeaderName].ToString()))
                return Results.BadRequest();

            string? apiKey = context.HttpContext.Request.Headers[Constants.ApiKeyHeaderName];

            if (!_apiKeyValidation.IsValidApiKey(apiKey!))
            {
                return Results.Unauthorized();
            }

            return await next(context);
        }
    }
}