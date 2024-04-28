using Microsoft.AspNetCore.Mvc;
using StrawberryShake;
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
}
