using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestcontainersForDotNetAndDocker.Contracts.Requests;
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

    [HttpPost("CreateCat"), AllowAnonymous]
    public async Task<ActionResult> CreateCatAsync(CreateCatRequest createCatRequest)
    {
        return await Task.FromResult(new OkObjectResult(null));
    }
}
