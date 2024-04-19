namespace HttpClientDefaultAndPerRequestTimeOut.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class FakeSlowApiController : ControllerBase
{
    [HttpGet("/api/delay-4-seconds")]
    public async Task GetOrderById(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(4), cancellationToken);
    }
}
