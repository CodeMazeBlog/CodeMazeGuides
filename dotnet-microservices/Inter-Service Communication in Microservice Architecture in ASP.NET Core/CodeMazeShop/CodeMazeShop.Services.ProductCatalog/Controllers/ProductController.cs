using AutoMapper;
using CodeMazeShop.Services.ProductCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using DataContract = CodeMazeShop.DataContracts.ProductCatalog;

namespace CodeMazeShop.Services.ProductCatalog.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductCatalogRepository _productCatalogRepository;
    private readonly IMapper _mapper;

    public ProductController(IProductCatalogRepository productCatalogRepository, IMapper mapper)
    {
        _productCatalogRepository = productCatalogRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DataContract.Product>>> Get([FromQuery] string? categoryId)
    {
        var result = await _productCatalogRepository.GetProductsByCategoryId(categoryId);
        return Ok(_mapper.Map<List<DataContract.Product>>(result));
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<DataContract.Product>> GetById(string productId)
    {
        var result = await _productCatalogRepository.GetProduct(productId);
        return Ok(_mapper.Map<DataContract.Product>(result));
    }

}