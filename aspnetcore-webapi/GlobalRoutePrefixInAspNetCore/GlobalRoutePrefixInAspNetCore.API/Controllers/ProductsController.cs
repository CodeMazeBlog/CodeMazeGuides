using GlobalRoutePrefixInAspNetCore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalRoutePrefixInAspNetCore.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product { Id = 1,Name = "The Secret Recipes of Chef Uyi",Category = "Book",Price = 100},
                new Product { Id = 2,Name = "Lenovo Yoga Laptop",Category = "Tech Gadget",Price = 2000}
            };

            return Ok(products);
        }
    }
}