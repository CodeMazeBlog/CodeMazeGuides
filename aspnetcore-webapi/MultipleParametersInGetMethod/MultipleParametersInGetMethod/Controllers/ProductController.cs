using Microsoft.AspNetCore.Mvc;

namespace MultipleParametersInGetMethod.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product{ Id = 1, Category = "Electronic", Brand = "Sony" },
            new Product{ Id = 2, Category = "Clothing", Brand = "Adidas" },
            new Product{ Id = 3, Category = "Sports", Brand = "Nike" }
        };

        [HttpGet("query-params")]
        public ActionResult<Product?> GetProductsUsingQueryParams([FromQuery] string category, [FromQuery] string brand)
        {
            return Ok(products
                        .Where(x => x.Category == category && x.Brand == brand)
                        .FirstOrDefault());
        }

        [HttpGet("route-params/{id}/{brand}")]
        public ActionResult<Product?> GetProductsUsingRouteParams([FromRoute] int id, [FromRoute] string brand)
        {
            return Ok(products
                        .Where(x => x.Id == id && x.Brand == brand)
                        .FirstOrDefault());
        }

        [HttpGet("request-body")]
        public ActionResult<Product?> GetProductsUsingRequestBody([FromBody] Product model)
        {
            return Ok(products
                        .Where(x => x.Id == model.Id && x.Category == model.Category)
                        .FirstOrDefault());
        }

        [HttpGet("route-query-params/{id}")]
        public ActionResult<Product?> GetProductsUsingRouteAndQueryParams([FromRoute] int id, [FromQuery] string brand)
        {
            return Ok(products
                        .Where(x => x.Id == id && x.Brand == brand)
                        .FirstOrDefault());
        }

        [HttpGet("parameter-binding")]
        public ActionResult<Product?> GetProductsUsingParamterBinding(string category, string brand, int id)
        {
            return Ok(products
                        .Where(x => x.Id == id && x.Category == category && x.Brand == brand)
                        .FirstOrDefault());
        }
    }
}