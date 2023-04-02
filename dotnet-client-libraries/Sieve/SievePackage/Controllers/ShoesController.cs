using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;

namespace SievePackage.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoesController : ControllerBase
{
    private static readonly List<Shoe> _shoes = new()
    {
        new()
        {
            Id = 1,
            Name = "Pegasus 39",
            Brand = "Nike",
            Price = 119.99M,
            Category = "Running",
            Rating = 4.5M
        },
        new()
        {
            Id = 2,
            Name = "Pegasus Trail 3",
            Brand = "Nike",
            Price = 119.99M,
            Category = "Trail",
            Rating = 3.8M
        },
        new()
        {
            Id = 3,
            Name = "Ride 15",
            Brand = "Saucony",
            Price = 59.99M,
            Category = "Neutral",
            Rating = 4.9M
        }
    };

    private readonly SieveProcessor _sieveProcessor;

    public ShoesController(SieveProcessor sieveProcessor)
    {
        _sieveProcessor = sieveProcessor;
    }

    [HttpGet]
    public IActionResult GetShoes([FromQuery]SieveModel sieveModel)
    {
        var result = _sieveProcessor.Apply(sieveModel, _shoes.AsQueryable());

        return Ok(result);
    }
}
