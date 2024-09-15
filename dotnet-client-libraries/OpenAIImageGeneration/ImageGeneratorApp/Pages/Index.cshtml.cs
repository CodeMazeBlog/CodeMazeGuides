using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;

namespace ImageGeneratorApp.Pages;

public class IndexModel(IHttpClientFactory clientFactory,
    IConfiguration configuration) : PageModel
{
    [BindProperty]
    public required string Prompt { get; set; }
    [BindProperty]
    public required string Size { get; set; }
    [BindProperty]
    public required string Style { get; set; }
    [BindProperty]
    public required string Quality { get; set; }
    public string? ImageUrl { get; set; }
    public string Message { get; set; } = "Please submit a prompt to generate an image.";

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var client = clientFactory.CreateClient();

        var requestBody = new
        {
            Prompt,
            Size,
            Style,
            Quality
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync(configuration["ApiUrl"], content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<ImageResponse>(responseContent, options);

                ImageUrl = result?.ImageUri;
            }
            else
            {
                Message = "An error occurred while generating the image. Please try again later.";
            }
        }
        catch
        {
            Message = "An error occurred while generating the image. Please try again later.";
        }

        return Page();
    }
}
