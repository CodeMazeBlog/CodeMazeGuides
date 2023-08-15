using Microsoft.AspNetCore.Mvc;
using TestcontainersForDotNetAndDocker.Contracts.Requests;
using TestcontainersForDotNetAndDocker.Contracts.Responses;
using TestcontainersForDotNetAndDocker.Domain;
using TestcontainersForDotNetAndDocker.Services;

namespace TestcontainersForDotNetAndDocker.Controllers;

[ApiController]
public class CatController : ControllerBase
{
    private readonly ICatService _catService;

    public CatController(ICatService catService)
    {
        _catService = catService;
    }

    [HttpPost("CreateCat")]
    public async Task<ActionResult<CatResponse>> CreateCatAsync(CreateCatRequest request)
    {
        var cat = new Cat(
            request.Name,
            request.Age,
            request.Weight);

        var result = await _catService.CreateCatAsync(cat);

        if (result)
        {
            var catResponse = new CatResponse(
                cat.Id,
                cat.Name,
                cat.Age,
                cat.Weight);

            return CreatedAtAction(
                "GetCat",
                new { id = catResponse.Id },
                catResponse);
        }

        return BadRequest();
    }

    [HttpDelete("DeleteCat/{id}")]
    public async Task<ActionResult> DeleteCatAsync(Guid id)
    {
        var result = await _catService.DeleteCatAsync(id);

        if (result)
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpGet("GetAllCats")]
    public async Task<ActionResult<GetAllCatsResponse>> GetAllCatsAsync()
    {
        var cats = await _catService.GetAllCatsAsync();
        var catResponses = new List<CatResponse>();

        foreach (var cat in cats)
        {
            catResponses.Add(
                new CatResponse(
                    cat.Id,
                    cat.Name,
                    cat.Age,
                    cat.Weight));
        }

        var allCatsResponse = new GetAllCatsResponse(catResponses);

        return Ok(allCatsResponse);
    }

    [HttpGet("GetCat/{id}")]
    public async Task<ActionResult<CatResponse>> GetCatAsync(Guid id)
    {
        var cat = await _catService.GetCatAsync(id);

        if (cat is null)
        {
            return NotFound();
        }

        var catResponse = new CatResponse(
            cat.Id,
            cat.Name,
            cat.Age,
            cat.Weight);

        return Ok(catResponse);
    }

    [HttpPut("UpdateCat")]
    public async Task<ActionResult<CatResponse>> UpdateCatAsync(UpdateCatRequest request)
    {
        var cat = new Cat(
            request.Name,
            request.Age,
            request.Weight)
        {
            Id = request.Id
        };

        var result = await _catService.UpdateCatAsync(cat);

        if (result)
        {
            var catResponse = new CatResponse(
                cat.Id,
                cat.Name,
                cat.Age,
                cat.Weight);

            return Ok(catResponse);
        }

        return NotFound();
    }
}
