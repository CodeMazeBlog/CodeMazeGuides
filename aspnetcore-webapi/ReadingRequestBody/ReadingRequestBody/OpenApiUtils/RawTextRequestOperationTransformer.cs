using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace ReadingRequestBody.OpenApiUtils;

public class RawTextRequestOperationTransformer : IOpenApiOperationTransformer
{
    public Task TransformAsync(OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken cancellationToken)
    {
        if (context.Description.ActionDescriptor.EndpointMetadata
                .OfType<RawTextRequestAttribute>()
                .SingleOrDefault() is RawTextRequestAttribute rawTextRequestAttribute)
        {
            operation.RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    [rawTextRequestAttribute.MediaType] = new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema { Type = JsonSchemaType.String }
                    }
                }
            };
        }

        return Task.CompletedTask;
    }
}
