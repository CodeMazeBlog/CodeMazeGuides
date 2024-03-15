using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ReadingRequestBody.SwaggerUtils;
public class RawTextRequestOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.MethodInfo.GetCustomAttributes(true).SingleOrDefault((attribute) => attribute is SwaggerEnableRawTextAttribute) is SwaggerEnableRawTextAttribute rawTextRequestAttribute)
        {
            operation.RequestBody = new OpenApiRequestBody();
            operation.RequestBody.Content.Add(rawTextRequestAttribute.MediaType, new OpenApiMediaType()
            {
                Schema = new OpenApiSchema()
                {
                    Type = "string"
                }
            });
        }
    }
}
