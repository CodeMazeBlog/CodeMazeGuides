using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultipleParametersInGetMethod.Models;

namespace MultipleParametersInGetMethod.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product{ Id = 1, Category = "Electronic", Brand = "Sony", Name = "Play Station", WarrantyYears = 2, IsAvailable = true },
            new Product{ Id = 2, Category = "Electronic", Brand = "Sony", Name = "Mobile", WarrantyYears = 2, IsAvailable = true },
            new Product{ Id = 3, Category = "Electronic", Brand = "LG", Name = "TV", WarrantyYears = 2, IsAvailable = true },
            new Product{ Id = 4, Category = "Clothing", Brand = "Adidas", Name = "Shoes", WarrantyYears = 3, IsAvailable = true },
            new Product{ Id = 5, Category = "Sports", Brand = "Nike", Name = "Sneakers", WarrantyYears = 3, IsAvailable = false },
            new Product{ Id = 6, Category = "Sports", Brand = "Adidas", Name = "Football", WarrantyYears = 3, IsAvailable = false },
            new Product{ Id = 7, Category = "Electronic", Brand = "Apple", Name = "Mobile", WarrantyYears = 2, IsAvailable = true }
        };
        private readonly IMapper mapper;

        public ProductController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductsByCategoryAndBrand([FromQuery] string category, [FromQuery] string brand)
        {
            var result = products
                        .Where(x => x.Category == category && x.Brand == brand)
                        .ToList();

            return Ok(mapper.Map<List<ProductDto>>(result));
        }

        [HttpGet("{id}")]
        public IActionResult GetProductUsingId([FromRoute] int id)
        {
            return Ok(mapper.Map<ProductDto>(products
                        .Where(x => x.Id == id)
                        .FirstOrDefault()));
        }

        [HttpGet("category")]
        public ActionResult<Product?> GetProductsByCategory([FromBody] ProductDto model)
        {
            return Ok(mapper.Map<List<ProductDto>>(products
                        .Where(x => x.Category == model.Category)
                        .ToList()));
        }

        [HttpGet("v1/filter")]
        public IActionResult FilterProductsByHeaderParams([FromHeader] string name, [FromHeader] bool isAvailable)
        {
            return Ok(mapper.Map<List<ProductDto>>(products
                        .Where(x => x.Name == name && x.IsAvailable == isAvailable)
                        .ToList()));
        }

        [HttpGet("brand/{brand}/warranty")]
        public IActionResult GetProductsByBrandAndWarranty([FromRoute] string brand, [FromQuery] int waranty)
        {
            return Ok(mapper.Map<List<ProductDto>>(products
                        .Where(x => x.Brand == brand && x.WarrantyYears == waranty)
                        .ToList()));
        }
    }
}