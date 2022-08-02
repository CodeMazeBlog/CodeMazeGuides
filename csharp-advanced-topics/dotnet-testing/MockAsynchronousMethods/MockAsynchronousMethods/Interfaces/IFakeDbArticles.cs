using MockAsynchronousMethods.Repository.DbModels;

namespace MockAsynchronousMethods.Repository.Interfaces
{
    public interface IFakeDbArticles
    {
        Task<IEnumerable<ArticleDbModel>> GetAsync();
        Task<ArticleDbModel?> GetByIdAsync(int id);
    }
}
