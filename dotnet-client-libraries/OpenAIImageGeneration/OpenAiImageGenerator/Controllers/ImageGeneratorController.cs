using Microsoft.AspNetCore.Mvc;
using OpenAiImageGenerator.Services;

namespace OpenAiImageGenerator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageGeneratorController(IOpenAIService openAIService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync(ImageGenerationApiModel apiModel)
    {
        try
        {
            var imageUri = await openAIService.GenerateImageAsync(apiModel);

            return Ok(new { ImageUri = imageUri });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
