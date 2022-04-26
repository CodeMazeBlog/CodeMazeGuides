using API.Model;
using System.Text.Json;

namespace API.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            var languageData = File.ReadAllText("Data/LanguageSeedData.json");
            var languages = JsonSerializer.Deserialize<List<Language>>(languageData);

            if (!_context.Languages.Any())
            {
                _context.Languages.AddRange(languages);
            }

            _context.SaveChanges();
        }
    }
}
