using Microsoft.AspNetCore.Mvc;
using StrawberryShake;
using StrawberryShake.Extensions;
using System.Text.Json;

namespace GraphQLStrawberryShakeSubs.Controllers;

[ApiController]
[Route("[controller]")]
public class ShippingContainerController(IShippingContainerSubClient client) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetShippingContainers()
    {
        var result = await client.GetShippingContainersName.ExecuteAsync();
        result.EnsureNoErrors();

        return Ok(JsonSerializer.Serialize(result.Data!.ShippingContainers));
    }

    [HttpGet("added")]
    public async Task<IActionResult> OnContainerAdded()
    {
        var name = "";
        var tcs = new TaskCompletionSource<string>();
        IDisposable subscription = null!;

        subscription = client.OnContainerAdded
            .Watch()
            .Subscribe(result =>
            {
                result.EnsureNoErrors();
                name = result.Data!.OnShippingContainerAdded.Name;
                subscription?.Dispose();
                tcs.SetResult(name);
            });

        name = await tcs.Task;

        return Ok(JsonSerializer.Serialize(name));
    }

    [HttpGet("updated")]
    public async Task<IActionResult> OnContainerSpaceChanged()
    {
        var tcs = new TaskCompletionSource<(string, double)>();
        IDisposable subscription = null!;

        subscription = client.OnContainerSpaceChanged
            .Watch()
            .Subscribe(result =>
            {
                result.EnsureNoErrors();

                tcs.SetResult((result.Data!.OnShippingContainerSpaceChanged.Name,
                    result.Data!.OnShippingContainerSpaceChanged.Space!.Volume));
                subscription?.Dispose();
            });

        (var name, var volume) = await tcs.Task;

        return Ok(JsonSerializer.Serialize(new { name, volume }));
    }
}
