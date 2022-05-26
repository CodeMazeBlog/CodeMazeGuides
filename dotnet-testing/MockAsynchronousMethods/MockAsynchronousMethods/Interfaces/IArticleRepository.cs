using MockAsynchronousMethods.Repository.DbModels;

namespace MockAsynchronousMethods.Repository.Interfaces
{
    public interface IArticleRepository
    {
        Task<ArticleDbModel?> GetArticleAsync(int id);
        Task<IEnumerable<ArticleDbModel>> GetAllArticlesAsync();
    }
}
