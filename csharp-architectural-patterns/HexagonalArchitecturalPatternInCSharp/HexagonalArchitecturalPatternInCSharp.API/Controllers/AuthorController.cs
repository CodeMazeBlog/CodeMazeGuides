using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driving;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HexagonalArchitecturalPatternInCSharp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
    {
        _logger = logger;
        _authorService = authorService;
    }

    [HttpGet]
    [Route("GetById/{authorId}")]
    public async Task<ActionResult> GetById(Guid authorId)
    {
        var author = await _authorService.GetByIdAsync(authorId);

        return Ok(author);
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var authors = await _authorService.GetAllAsync();

        return Ok(authors);
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] Author author)
    {
        await _authorService.AddAsync(author);
        _logger.LogInformation("Author {authorName} added", author.Name);

        return Ok(author);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid authorId)
    {
        await _authorService.DeleteAsync(authorId);
        _logger.LogInformation("Author {authorId} was deleted", authorId);

        return Ok();
    }
}