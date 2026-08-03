using Microsoft.AspNetCore.Mvc;

namespace OptionalParameterinWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static readonly string[] Products = new[]
        {
            "Sweater", "Umbrella", "Jacket", "Polo", "Boots", "Microwave", "Schoolbag", "Sunshade", "SKinny Jeans", "Sunscreen"
        };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = new List<Product>();

            for (int i = 0; i < Products.Length; i++)
            {
                products.Add(new Product
                {
                    Id = i + 1,
                    Price = ($" ${Random.Shared.Next(100, 6000)}"),
                    Name = Products[i]
                });
            }

            return products;
        }

        [HttpGet("GetById/{id:int?}")]
        public Product GetById(int id = 1)
        {
            var products = Get();

            return products.Where(p => p.Id == id).FirstOrDefault()!;
        }
    }
}

