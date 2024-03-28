using System.Text.Json;
using GraphQLStrawberryShake.GraphQL;
using Microsoft.AspNetCore.Mvc;
using StrawberryShake;

namespace GraphQLStrawberryShake.Controllers;

[ApiController]
[Route("[controller]")]
public class ShippingContainerController(IShippingContainerClient client) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetShippingContainers()
    {
        var result = await client.GetShippingContainersName.ExecuteAsync();
        result.EnsureNoErrors();

        return Ok(JsonSerializer.Serialize(result.Data!.ShippingContainers));
    }
}
