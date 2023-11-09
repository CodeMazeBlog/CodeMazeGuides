using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptimisticConcurrency.Data;
using OptimisticConcurrency.Model;

namespace OptimisticConcurrency.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private const string ETagHeader = "ETag";
    private const string IfMatchHeader = "If-Match";

    private readonly ProductDbContext _context;

    public ProductsController(ProductDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
    {
        if (_context.Product is null)
        {
            return NotFound();
        }
        return await _context.Product.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        if (_context.Product == null)
        {
            return NotFound();
        }
        var product = await _context.Product.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            id = product.Id,
            name = product.Name,
            price = product.Price,
            links = new[]
            {
                new { rel = "edit", href = $"/products/{id}/{product.Version}", method = "PUT" }
            }
        });
    }

    [HttpPut("{id}/{version}")]
    public async Task<IActionResult> PutProduct(int id, string version, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        var currentProduct = await _context.Product.FindAsync(id);
        if (currentProduct == null)
        {
            return NotFound();
        }

        var currentVersion = currentProduct.Version.ToString();
        if (version != currentVersion)
        {
            return StatusCode(StatusCodes.Status412PreconditionFailed);
        }

        _context.Entry(currentProduct).CurrentValues.SetValues(product);
        currentProduct.Version = Guid.NewGuid();
        _context.Entry(currentProduct).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        if (_context.Product == null)
        {
            return Problem("Entity set 'ProductDbContext.Product'  is null.");
        }

        product.Version = Guid.NewGuid();
        _context.Product.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (_context.Product == null)
        {
            return NotFound();
        }
        var product = await _context.Product.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Product.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
