using Microsoft.AspNetCore.Mvc;

using RegisterServicesForEnvironments.Services;

namespace RegisterServicesForEnvironments.Controllers
{
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

       
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();

            return Ok(products);
        }
    }
}
