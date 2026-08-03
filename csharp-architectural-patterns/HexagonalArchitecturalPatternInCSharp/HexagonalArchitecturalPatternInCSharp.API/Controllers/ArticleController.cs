using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driving;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HexagonalArchitecturalPatternInCSharp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    private readonly ILogger<ArticleController> _logger;
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService, ILogger<ArticleController> logger)
    {
        _logger = logger;
        _articleService = articleService;
    }

    [HttpGet]
    [Route("GetById/{articleId}")]
    public async Task<ActionResult> GetById(Guid articleId)
    {
        var article = await _articleService.GetByIdAsync(articleId);

        return Ok(article);
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var articles = await _articleService.GetAllAsync();

        return Ok(articles);
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] Article article)
    {
        await _articleService.AddAsync(article);
        _logger.LogInformation("Article {articleTitle} added", article.Title);

        return Ok(article);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid articleId)
    {
        await _articleService.DeleteAsync(articleId);
        _logger.LogInformation("Article {articleId} was deleted", articleId);

        return Ok();
    }
}