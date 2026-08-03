using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsingAuthorizationWithSwagger.Data;

namespace UsingAuthorizationWithSwagger.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet, Authorize]
        public IActionResult GetAllProducts()
        {
            var products = ProductStore.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetAProduct(int id)
        {
            var product = ProductStore.GetProduct(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }
    }
}
