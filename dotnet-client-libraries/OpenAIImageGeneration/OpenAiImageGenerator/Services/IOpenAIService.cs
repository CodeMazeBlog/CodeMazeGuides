namespace OpenAiImageGenerator.Services;

public interface IOpenAIService
{
    Task<Uri> GenerateImageAsync(ImageGenerationApiModel imageGenerationApiModel);
}
