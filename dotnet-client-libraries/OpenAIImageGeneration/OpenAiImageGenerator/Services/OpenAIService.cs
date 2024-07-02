using Azure.AI.OpenAI;

namespace OpenAiImageGenerator.Services;

public class OpenAIService : IOpenAIService
{
    readonly IConfiguration _configuration;
    readonly OpenAIClient _openAIClient;

    public OpenAIService(IConfiguration configuration, OpenAIClient openAIClient)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _openAIClient = openAIClient ?? throw new ArgumentNullException(nameof(openAIClient));
    }

    public async Task<Uri> GenerateImageAsync(ImageGenerationApiModel imageGenerationApiModel)
    {
        ImageGenerationOptions imageGenerationOptions = new()
        {
            Prompt = imageGenerationApiModel.Prompt,
            Size = imageGenerationApiModel.Size,
            DeploymentName = _configuration["AzureOpenAiDeploymentName"],
            Quality = imageGenerationApiModel.Quality,
            Style = imageGenerationApiModel.Style
        };

        var imageGenerations =
            await _openAIClient.GetImageGenerationsAsync(imageGenerationOptions);

        var imageUri = imageGenerations.Value.Data[0].Url;

        return imageUri;
    }
}