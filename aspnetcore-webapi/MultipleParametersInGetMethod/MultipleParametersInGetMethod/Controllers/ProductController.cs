using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultipleParametersInGetMethod.Models;

namespace MultipleParametersInGetMethod.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly List<Product> _products = new()
        {
            new Product{ Id = 1, Category = "Electronic", Brand = "Sony", Name = "Play Station", WarrantyYears = 2, IsAvailable = true },
            new Product{ Id = 2, Category = "Electronic", Brand = "Sony", Name = "Mobile", WarrantyYears = 2, IsAvailable = true },
            new Product{ Id = 3, Category = "Electronic", Brand = "LG", Name = "TV", WarrantyYears = 2, IsAvailable = true },
            new Product{ Id = 4, Category = "Clothing", Brand = "Adidas", Name = "Shoes", WarrantyYears = 3, IsAvailable = true },
            new Product{ Id = 5, Category = "Sports", Brand = "Nike", Name = "Sneakers", WarrantyYears = 3, IsAvailable = false },
            new Product{ Id = 6, Category = "Sports", Brand = "Adidas", Name = "Football", WarrantyYears = 3, IsAvailable = false },
            new Product{ Id = 7, Category = "Electronic", Brand = "Apple", Name = "Mobile", WarrantyYears = 2, IsAvailable = true }
        };
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductsByCategoryAndBrand(string category, string brand)
        {
            List<Product> result = _products
                .Where(x => x.Category == category && x.Brand == brand)
                .ToList();

            return Ok(_mapper.Map<List<ProductDto>>(result));
        }

        [HttpGet("type-manufacturer")]
        public IActionResult GetProductsByCategoryAndBrandUsingFromQuery(
            [FromQuery(Name = "type")] string category,
            [FromQuery(Name = "manufacturer")] string brand)
        {
            List<Product> result = _products
                .Where(x => x.Category == category && x.Brand == brand)
                .ToList();

            return Ok(_mapper.Map<List<ProductDto>>(result));
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_mapper.Map<ProductDto>(_products
                .Where(x => x.Id == id)
                .FirstOrDefault()));
        }

        [HttpGet("productId/{productId}")]
        public IActionResult GetProductByIdUsingFromRoute([FromRoute(Name = "productId")] int id)
        {
            return Ok(_mapper.Map<ProductDto>(_products
                .Where(x => x.Id == id)
                .FirstOrDefault()));
        }

        [HttpGet("brand/{brand}")]
        public IActionResult GetProductsByBrandAndWarranty(string brand, int warranty)
        {
            return Ok(_mapper.Map<List<ProductDto>>(_products
                .Where(x => x.Brand == brand && x.WarrantyYears == warranty)
                .ToList()));
        }

        [HttpGet("manufacturer/{manufacturer}")]
        public IActionResult GetProductsByBrandAndWarrantyUsingAttributes(
            [FromRoute(Name = "manufacturer")] string brand,
            [FromQuery(Name = "coverage")] int warranty)
        {
            return Ok(_mapper.Map<List<ProductDto>>(_products
                .Where(x => x.Brand == brand && x.WarrantyYears == warranty)
                .ToList()));
        }

        [HttpGet("category")]
        public IActionResult GetProductsByCategory([FromBody] ProductDto model)
        {
            return Ok(_mapper.Map<List<ProductDto>>(_products
                .Where(x => x.Category == model.Category)
                .ToList()));
        }

        [HttpGet("category-brand")]
        public IActionResult GetProductsByCategoryAndBrandViaHeaders([FromHeader] string category, [FromHeader] string brand)
        {
            return Ok(_mapper.Map<List<ProductDto>>(_products
                .Where(x => x.Category == category && x.Brand == brand)
                .ToList()));
        }
    }
}