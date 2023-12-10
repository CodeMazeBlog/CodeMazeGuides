using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driving;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HexagonalArchitecturalPatternInCSharp.Controllers;

[ApiController]
[Route("[controller]")]
public class WritingController : ControllerBase
{
    private readonly ILogger<WritingController> _logger;
    private readonly IWritingService _writingService;

    public WritingController(IWritingService writingService, ILogger<WritingController> logger)
    {
        _logger = logger;
        _writingService = writingService;
    }

    [HttpPost]
    public async Task<ActionResult> StartWriting(Guid authorId, Guid articleId)
    {
        await _writingService.StartWritingAsync(authorId, articleId);
        _logger.LogInformation("Author {authorId} started to write article {articleId}", authorId, articleId);

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> ChangeStatus(Guid articleId, WritingStatus writingStatus)
    {
        await _writingService.ChangeArticleStatusAsync(articleId, writingStatus);
        _logger.LogInformation("Status of the article {articleId} change to {writingStatus}", articleId, writingStatus);

        return Ok();
    }
}