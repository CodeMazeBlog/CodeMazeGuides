using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HideEndpointInSwagger.Filters;

public class SwaggerDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Paths.Remove("/WeatherForecast/GetMethodFour");
    }
}
