using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuditLogApp.Data;
using AuditLogApp.Models;
using System.Text.Json;

namespace AuditLogApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductsDbContext _context;

    public ProductsController(ProductsDbContext context)
    {
        _context = context;
    }

    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
    {
        if (_context.Products is null)
        {
            return NotFound();
        }

        return await _context.Products.ToListAsync();
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        if (_context.Products is null)
        {
            return NotFound();
        }

        var product = await _context.Products.FindAsync(id);
        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    // PUT: api/Products/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        var oldProduct = await _context.Products.FindAsync(id);
        if (oldProduct is null)
        {
            return NotFound();
        }

        _context.Entry(oldProduct).CurrentValues.SetValues(product);

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

    // POST: api/Products
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        if (_context.Products is null)
        {
            return Problem("Entity set 'ProductsDbContext.Product'  is null.");
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (_context.Products is null)
        {
            return NotFound();
        }
        var product = await _context.Products.FindAsync(id);
        if (product is null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
