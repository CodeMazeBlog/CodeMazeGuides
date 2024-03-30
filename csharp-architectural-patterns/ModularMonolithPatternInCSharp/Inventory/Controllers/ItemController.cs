using Inventory.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController(IItemService itemService) : ControllerBase
{
    private readonly IItemService _itemService = itemService;

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var item = _itemService.Get(id);

        return item is null ?
            NotFound(id) : 
            Ok(item);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var items = _itemService.GetAll();

        return Ok(items);
    }
}
