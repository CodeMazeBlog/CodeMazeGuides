using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestcontainersForDotNetAndDocker.Contracts.Requests;
using TestcontainersForDotNetAndDocker.Contracts.Responses;
using TestcontainersForDotNetAndDocker.Domain;
using TestcontainersForDotNetAndDocker.Services;

namespace TestcontainersForDotNetAndDocker.Controllers;

[ApiController, AllowAnonymous]
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

            return Ok(catResponse);
        }

        return BadRequest();
    }

    [HttpDelete("DeleteCat")]
    public async Task<ActionResult> DeleteCatAsync(DeleteCatRequest request)
    {
        var result = await _catService.DeleteCatAsync(request.Id);

        if (result)
        {
            return Ok();
        }

        return BadRequest();
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

    [HttpGet("GetCat")]
    public async Task<ActionResult<CatResponse>> GetCatAsync(GetCatRequest request)
    {
        var cat = await _catService.GetCatAsync(request.Id);

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
            request.Weight);

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

        return BadRequest();
    }
}
