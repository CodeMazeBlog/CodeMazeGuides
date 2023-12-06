using HowToUseRequestTimeoutsMiddleware.Data;
using HowToUseRequestTimeoutsMiddleware.Services;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;

namespace HowToUseRequestTimeoutsMiddleware.Controllers;

[ApiController]
[Route("[controller]")]
public class StarWarsController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public StarWarsController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("GetCharacter")]
    [RequestTimeout("OneSecondTimeout")]
    public async Task<Character> GetCharacterAsync()
        => await _characterService.GetCharacterAsync(HttpContext.RequestAborted);

    [HttpGet("GetCharacterWithDefaultTimeout")]
    public async Task<Character> GetCharacterWithDefaultTimeoutAsync()
        => await _characterService.GetCharacterAsync(HttpContext.RequestAborted);
}