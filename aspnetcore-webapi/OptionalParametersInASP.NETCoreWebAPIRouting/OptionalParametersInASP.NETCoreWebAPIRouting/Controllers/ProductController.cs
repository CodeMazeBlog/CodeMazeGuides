using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OptionalParametersInASP.NETCoreWebAPIRouting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static readonly string[] Products = new[]
        {
        "Sweater", "Umbrella", "Jacket", "Polo", "Boots", "Microwave", "Schoolbag", "Sunshade", "SKinny Jeans", "Sunscreen"
         };

        private readonly ILogger<WeatherForecastController> _logger;

        public ProductController(ILogger<WeatherForecastController> logger)
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

        [HttpGet("GetBy/{name}")]
        public Product GetBy(string name)
        {
            var products = Get();

            return products.Where(p => p.Name == name).FirstOrDefault()!;    
        }

        [HttpGet("GetBy/{id:int}")]
        public Product GetBy(int id)
        {
            var products = Get();

            return products.Where(p => p.Id == id).FirstOrDefault()!;
        }

        [HttpGet("GetById/{id:int?}")]
        public Product GetById(int id = 1)
        {
            var products = Get();

            return products.Where(p => p.Id == id).FirstOrDefault()!;
        }
    }
}
