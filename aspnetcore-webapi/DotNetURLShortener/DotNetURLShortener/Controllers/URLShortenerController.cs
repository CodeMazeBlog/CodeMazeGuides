using DotNetURLShortener.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortenerWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class URLShortenerController(IUrlShortenerService urlShortenerService) : ControllerBase
{
    [HttpGet("/{shortCode}")]
    public IActionResult GetLongUrl(string shortCode)
    {
        var longUrl = urlShortenerService.GetLongUrl(shortCode);

        if (longUrl is null)
        {
            return NotFound();
        }

        return Ok(longUrl);
    }

    [HttpGet("/samplepage")]
    public IActionResult GetSamplePage()
    {
        return Ok("This is a sample page to test our URL shortener.");
    }

    [HttpPost("/createshorturl")]
    public IActionResult ShortenUrl([FromBody] string longUrl)
    {
        if (!Uri.TryCreate(longUrl, UriKind.Absolute, out _))
        {
            return BadRequest("This is not a valid URL");
        }

        return Ok(urlShortenerService.GetShortCode(longUrl));
    }
}