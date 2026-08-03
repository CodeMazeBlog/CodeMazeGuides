namespace Minimal_API;

public interface IArticleService
{
    Task<IResult> GetArticles();

    Task<IResult> GetArticleById(int id);

    Task<IResult> CreateArticle(ArticleRequest article);

    Task<IResult> UpdateArticle(int id, ArticleRequest article);

    Task<IResult> DeleteArticle(int id);
}
