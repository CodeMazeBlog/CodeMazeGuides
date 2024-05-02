using Microsoft.AspNetCore.Mvc;
using StrawberryShake;
using StrawberryShake.Extensions;
using System.Text.Json;

namespace GraphQLStrawberryShakeSubs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShippingContainerSubsController(IShippingContainerSubClient client) : ControllerBase
{
    private readonly IShippingContainerSubClient client = client;

    [HttpGet]
    public IActionResult OnShippingContainerAdded()
    {
        var name = "";
        client.OnShippingContainerAdded
            .Watch()
            .Subscribe(result =>
            {
                result.EnsureNoErrors();
                name = result.Data!.OnShippingContainerAdded.Name;
            });

        return Ok(JsonSerializer.Serialize(name));
    }
}
