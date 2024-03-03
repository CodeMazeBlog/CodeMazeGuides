using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using GraphQLStrawberryShake.GraphQL;
using StrawberryShake;

namespace GraphQLStrawberryShake.Controllers;

[ApiController]
[Route("[controller]")]
public class ShippingContainerController : ControllerBase
{
    private readonly IShippingContainerClient _client;

    public ShippingContainerController(IShippingContainerClient client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<IActionResult> GetShippingContainers()
    {
        var result = await _client.GetShippingContainersName.ExecuteAsync();
        result.EnsureNoErrors();

        return Ok(JsonSerializer.Serialize(result.Data!.ShippingContainers));
    }
}
