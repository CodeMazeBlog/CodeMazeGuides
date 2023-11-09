using MockAsynchronousMethods.Repository.DbModels;
using MockAsynchronousMethods.Repository.Interfaces;

namespace MockAsynchronousMethods.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IFakeDbArticles _fakeDbArticle;

        public ArticleRepository(IFakeDbArticles fakeDbArticle)
        {
            _fakeDbArticle = fakeDbArticle;
        }

        public async Task<ArticleDbModel?> GetArticleAsync(int id)
        {
            return await _fakeDbArticle.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ArticleDbModel>> GetAllArticlesAsync()
        {
            return await _fakeDbArticle.GetAsync();
        }
    }
}