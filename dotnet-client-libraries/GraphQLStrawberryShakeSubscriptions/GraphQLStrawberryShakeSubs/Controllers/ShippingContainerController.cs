using Microsoft.AspNetCore.Mvc;
using StrawberryShake;
using StrawberryShake.Extensions;
using System.Text.Json;

namespace GraphQLStrawberryShakeSubs.Controllers;

[ApiController]
[Route("[controller]")]
public class ShippingContainerController(IShippingContainerSubClient client) : ControllerBase
{
    private readonly IShippingContainerSubClient client = client;

    [HttpGet]
    public async Task<IActionResult> GetShippingContainers()
    {
        var result = await client.GetShippingContainersName.ExecuteAsync();
        result.EnsureNoErrors();

        return Ok(JsonSerializer.Serialize(result.Data!.ShippingContainers));
    }

    [HttpGet("update")]
    public async Task<IActionResult> OnShippingContainerAdded()
    {
        var name = "";
        var tcs = new TaskCompletionSource<string>();
        IDisposable res = null!;

        res = client.OnShippingContainerAdded
            .Watch()
            .Subscribe(result =>
            {
                result.EnsureNoErrors();
                name = result.Data!.OnShippingContainerAdded.Name;
                res?.Dispose();
                tcs.SetResult(name);
            });

        name = await tcs.Task;

        return Ok(JsonSerializer.Serialize(name));
    }
}
