using AutoMapper;
using CodeMazeShop.Services.ProductCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using DataContract = CodeMazeShop.DataContracts.ProductCatalog;

namespace CodeMazeShop.Services.ProductCatalog.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IProductCatalogRepository _productCatalogRepository;
    private readonly IMapper _mapper;

    public CategoryController(IProductCatalogRepository productCatalogRepository, IMapper mapper)
    {
        _productCatalogRepository = productCatalogRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DataContract.Category>>> Get()
    {
        var result = await _productCatalogRepository.GetCategories();
        return Ok(_mapper.Map<List<DataContract.Category>>(result));
    }
}