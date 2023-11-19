using HowToUseRequestTimeoutsMiddleware.Services;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;

namespace HowToUseRequestTimeoutsMiddleware.Controllers;

[ApiController]
[Route("[controller]")]
public class StarWarsController : ControllerBase
{
    private readonly IStarWarsService _starWarsService;

    public StarWarsController(IStarWarsService starWarsService)
    {
        _starWarsService = starWarsService;
    }

    [HttpGet("GetCharacter")]
    [DisableRequestTimeout]
    public async Task<Character> GetCharacterAsync()
        => await _starWarsService.GetCharacterAsync(HttpContext.RequestAborted);
}