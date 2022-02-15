using Microsoft.EntityFrameworkCore;

namespace Minimal_API
{
    public static class ArticleService
    {
        public static async Task<IResult> GetArticles(ApiContext context)
        {
            return Results.Ok(await context.Articles.ToListAsync());
        }

        public static async Task<IResult> GetArticleById(ApiContext context, int id)
        {
            var article = await context.Articles.FindAsync(id);

            return article != null ? Results.Ok(article) : Results.NotFound();
        }

        public static async Task<IResult> CreateArticle(ArticleRequest article, ApiContext context)
        {
            var createdArticle = context.Articles.Add(new Article
            {
                Title = article.Title ?? string.Empty,
                Content = article.Content ?? string.Empty,
                PublishedAt = article.PublishedAt,
            });

            await context.SaveChangesAsync();

            return Results.Created($"/articles/{createdArticle.Entity.Id}", createdArticle.Entity);
        }

        public static async Task<IResult> UpdateArticle(int id, ArticleRequest article, ApiContext context)
        {
            var articleToUpdate = await context.Articles.FindAsync(id);

            if (articleToUpdate == null)
            {
                return Results.NotFound();
            }

            if (article.Title != null)
            {
                articleToUpdate.Title = article.Title;
            }

            if (article.Content != null)
            {
                articleToUpdate.Content = article.Content;
            }

            if (article.PublishedAt != null)
            {
                articleToUpdate.PublishedAt = articleToUpdate.PublishedAt;
            }

            await context.SaveChangesAsync();

            return Results.Ok(articleToUpdate);
        }

        public static async Task<IResult> DeleteArticle(int id, ApiContext context)
        {
            var article = await context.Articles.FindAsync(id);

            if (article == null)
            {
                return Results.NotFound();
            }

            context.Articles.Remove(article);

            await context.SaveChangesAsync();

            return Results.NoContent();
        }
    }
}
