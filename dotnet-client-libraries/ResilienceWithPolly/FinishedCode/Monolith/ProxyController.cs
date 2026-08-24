using Microsoft.AspNetCore.Mvc;
using Monolith.Resilience;
using Polly;
using Polly.Registry;

namespace Monolith;

[Route("[action]")]
[ApiController]
public class ProxyController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly ResiliencePipeline<IActionResult> _pipeline;

    public ProxyController(IHttpClientFactory httpClientFactory,
        ResiliencePipelineProvider<string> pipelineProvider)
    {
        _httpClient = httpClientFactory.CreateClient();
        _pipeline = pipelineProvider.GetPipeline<IActionResult>(ProxyPipeline.Name);
    }

    [HttpGet]
    public Task<IActionResult> Books() => ProxyTo("https://localhost:6001/books");

    [HttpGet]
    public Task<IActionResult> Authors() => ProxyTo("https://localhost:5001/authors");

    private async Task<IActionResult> ProxyTo(string url)
        => await _pipeline.ExecuteAsync(
            async token => (IActionResult)Content(await _httpClient.GetStringAsync(url, token)),
            HttpContext.RequestAborted);
}
