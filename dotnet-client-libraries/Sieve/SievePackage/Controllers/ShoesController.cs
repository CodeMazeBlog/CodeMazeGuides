using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;

namespace SievePackage.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoesController : ControllerBase
{
    private readonly ISieveProcessor _sieveProcessor;
    private readonly IShoeRetrievalService _shoeRetrievalService;

    public ShoesController(ISieveProcessor sieveProcessor, IShoeRetrievalService shoeRetrievalService)
    {
        _sieveProcessor = sieveProcessor;
        _shoeRetrievalService = shoeRetrievalService;
    }

    [HttpGet]
    public IActionResult GetShoes([FromQuery]SieveModel sieveModel)
    {
        var result = _sieveProcessor.Apply(sieveModel, _shoeRetrievalService.GetShoes());

        return Ok(result);
    }
}
