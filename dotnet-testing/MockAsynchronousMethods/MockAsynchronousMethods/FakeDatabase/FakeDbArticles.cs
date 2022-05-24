using MockAsynchronousMethods.Repository.DbModels;
using MockAsynchronousMethods.Repository.Interfaces;

namespace MockAsynchronousMethods.Repository.FakeDatabase
{
    public class FakeDbArticles : List<ArticleDbModel>, IFakeDbArticles
    {
        private readonly static List<ArticleDbModel> _articles = Populate();

        private static List<ArticleDbModel> Populate()
        {
            var result = new List<ArticleDbModel>()
            {
                new ArticleDbModel
                {
                    Id = 1,
                    Title = "First Article",
                    LastUpdate = DateTime.Now
                },
                new ArticleDbModel
                {
                    Id = 2,
                    Title = "Second title",
                    LastUpdate = DateTime.Now
                },
                new ArticleDbModel
                {
                    Id = 3,
                    Title = "Third title",
                    LastUpdate = DateTime.Now
                }
            };

            return result;
        }

        public async Task<IEnumerable<ArticleDbModel>> GetAsync()
        {
            await Task.Delay(10);

            return _articles;
        }

        public async Task<ArticleDbModel?> GetByIdAsync(int id)
        {
            await Task.Delay(10);

            return _articles.FirstOrDefault(x => x.Id == id);
        }
    }
}
