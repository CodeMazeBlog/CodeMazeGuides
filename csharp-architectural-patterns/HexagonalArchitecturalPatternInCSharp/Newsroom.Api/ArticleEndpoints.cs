using System.ComponentModel.DataAnnotations;
using Newsroom.Core.Ports.Driving;

namespace Newsroom.Api;

public sealed record CreateArticleRequest([property: Required, StringLength(200)] string Title);

public static class ArticleEndpoints
{
    public static void MapArticleEndpoints(this IEndpointRouteBuilder app)
    {
        var articles = app.MapGroup("/api/articles");

        articles.MapPost("/", async (
            CreateArticleRequest request,
            IArticleService service,
            CancellationToken cancellationToken) =>
        {
            var article = await service.CreateDraftAsync(request.Title, cancellationToken);

            return Results.Created($"/api/articles/{article.Id}", article);
        });

        articles.MapGet("/{articleId:int}", async (
            int articleId,
            IArticleService service,
            CancellationToken cancellationToken) =>
        {
            var result = await service.GetAsync(articleId, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });

        articles.MapPost("/{articleId:int}/publish", async (
            int articleId,
            IArticleService service,
            CancellationToken cancellationToken) =>
        {
            var result = await service.PublishAsync(articleId, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });
    }
}
