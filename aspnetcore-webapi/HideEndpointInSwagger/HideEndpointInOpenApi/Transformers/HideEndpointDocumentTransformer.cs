using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace HideEndpointInOpenApi.Transformers;

public class HideEndpointDocumentTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document,
        OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken)
    {
        document.Paths.Remove("/WeatherForecast/GetMethodFour");

        return Task.CompletedTask;
    }
}
