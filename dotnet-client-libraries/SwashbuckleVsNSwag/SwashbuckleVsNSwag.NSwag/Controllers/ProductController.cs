using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Models.Products;
using SwashbuckleVsNSwag.Repositories.ProductRepository;

namespace SwashbuckleVsNSwag.NSwag.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _products;

        public ProductController(ILogger<ProductController> logger, IProductRepository products)
        {
            _logger = logger;
            _products = products;
        }

        [HttpGet(Name = "GetProductById")]
        public ActionResult<Product> Get(Guid productId)
        {
            return _products.GetById(productId);
        }

        [HttpPost(Name = "PostProduc")]
        public ActionResult<Product> Post(Product product)
        {
            _products.Add(product);

            return product;
        }
    }
}