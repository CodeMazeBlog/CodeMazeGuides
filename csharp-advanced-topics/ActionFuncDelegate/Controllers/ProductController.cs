using ActionFuncDelegate.Data;
using ActionFuncDelegate.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionFuncDelegate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts(Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null)
        {
            var products = _repository.GetAll(orderBy);
            return Ok(products);
        }

        [HttpGet("get-product-by-id/{id}")]
        public IActionResult GetProductById(int id) => Ok(_repository.GetById(id));

        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _repository.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("update-product/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            var existingProduct = _repository.GetById(id);
            if (existingProduct == null)
                return NotFound();

            _repository.Update(product);
            return NoContent();
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
