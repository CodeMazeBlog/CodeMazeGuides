using APIsUsingSQLite.Data;
using APIsUsingSQLite.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIsUsingSQLite.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return context.Products;
    }

    [HttpPost]
    public ActionResult<Product> PostProduct(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();

        return CreatedAtAction("GetProductById", new { id = product.Id }, product);
    }
}
