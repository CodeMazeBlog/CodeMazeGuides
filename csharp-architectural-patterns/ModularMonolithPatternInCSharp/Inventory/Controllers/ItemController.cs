using Inventory.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController(IItemService itemService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var item = itemService.Get(id);

        return item is null ?
            NotFound(id) :
            Ok(item);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var items = itemService.GetAll();

        return Ok(items);
    }
}
