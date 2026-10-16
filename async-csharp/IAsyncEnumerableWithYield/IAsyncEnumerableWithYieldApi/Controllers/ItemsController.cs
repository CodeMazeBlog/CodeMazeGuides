using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ItemContext _context;

    public ItemsController(ItemContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet]
    public IAsyncEnumerable<Item> GetItems() =>
        _context.Items.AsNoTracking().AsAsyncEnumerable();
}
