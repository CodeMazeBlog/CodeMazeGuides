namespace OpenAiImageGenerator;

public class ImageGenerationApiModel
{
    public required string Prompt { get; set; }
    public required string Size { get; set; }
    public required string Style { get; set; }
    public required string Quality { get; set; }
}