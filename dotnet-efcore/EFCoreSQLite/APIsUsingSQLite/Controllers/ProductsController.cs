using APIsUsingSQLite.Data;
using APIsUsingSQLite.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIsUsingSQLite.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return _context.Products;
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _context.Products.Find(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public ActionResult<Product> PostProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();

        return CreatedAtAction("GetProductById", new { id = product.Id }, product);
    }

    [HttpDelete]
    public ActionResult<Product> DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        _context.SaveChanges();

        return product;
    }
}
