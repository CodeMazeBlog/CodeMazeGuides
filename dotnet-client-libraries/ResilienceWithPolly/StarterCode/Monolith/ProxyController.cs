using Microsoft.AspNetCore.Mvc;

namespace Monolith;

[Route("[action]")]
[ApiController]
public class ProxyController(IHttpClientFactory httpClientFactory) : ControllerBase
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

    [HttpGet]
    public Task<IActionResult> Books() => ProxyTo("https://localhost:6001/books");

    [HttpGet]
    public Task<IActionResult> Authors() => ProxyTo("https://localhost:5001/authors");

    private async Task<IActionResult> ProxyTo(string url)
        => Content(await _httpClient.GetStringAsync(url));
}
