using API.Model;

namespace API.Data
{
    public class LanguageRepository
    {
        private readonly DataContext _context;

        public LanguageRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _context.Languages.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
