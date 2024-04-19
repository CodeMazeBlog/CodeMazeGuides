namespace HttpClientDefaultAndPerRequestTimeOut.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class TimeOutTestsController(IHttpClientFactory httpClientFactory) : ControllerBase
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("TestClient");

    [HttpGet("/api/test-global-timeout")]
    public async Task<IActionResult> TestGlobalTimeOut()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/delay-4-seconds");

            // Do something with the response

            return Ok();
        }
        catch (TaskCanceledException)
        {
            return Ok("TaskCanceledException: HttpClient global timeout passed");
        }
    }

    [HttpGet("/api/test-per-request-timeout")]
    public async Task<IActionResult> TestPerRequestTimeout(CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/delay-4-seconds", cancellationToken);

            // Do something with the response

            return Ok();
        }
        catch (TaskCanceledException)
        {
            return Ok("TaskCanceledException: User request cancelled");
        }
    }

    [HttpGet("/api/test-combination-of-global-and-per-request-timeout")]
    public async Task<IActionResult> TestCombinationOfGlobalAndPerRequestTimeOut(CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/delay-4-seconds", cancellationToken);

            // Do something with the response

            return Ok();
        }
        catch (TaskCanceledException)
        {
            return Ok("TaskCanceledException: HttpClient global timeout passed");
        }
    }

    [HttpGet("/api/test-combined-timeout")]
    public async Task<IActionResult> TestGlobalTimeOut2(CancellationToken cancellationToken)
    {
        using var endpointSpecificToken = new CancellationTokenSource(TimeSpan.FromSeconds(2));
        using var tokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, endpointSpecificToken.Token);

        try
        {
            var response = await _httpClient.GetAsync("/api/delay-4-seconds", tokenSource.Token);

            // Do something with the response

            return Ok();
        }
        catch (TaskCanceledException)
        {
            return endpointSpecificToken.IsCancellationRequested
                ? Ok("TaskCanceledException: Specific token canceled")
                : Ok("TaskCanceledException: HttpClient global timeout passed");
        }
    }
}
