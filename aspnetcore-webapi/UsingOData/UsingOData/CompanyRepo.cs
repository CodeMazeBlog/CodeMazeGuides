using Microsoft.EntityFrameworkCore;

namespace UsingOData
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly ApiContext _context;
        public CompanyRepo(ApiContext context)
        {
            _context = context;
        }

        public IQueryable<Company> GetAll()
        {
            return _context.Companies
                .Include(a => a.Products)
                .AsQueryable();

        }

        public IQueryable<Company> GetById(int id)
        {
            return _context.Companies
                .Include(a => a.Products)
                .AsQueryable()
                .Where(c => c.ID == id);
        }

        public void Create(Company company)
        {
            _context.Companies
                .Add(company);
            _context.SaveChanges();
        }

        public void Update(Company company)
        {
            _context.Companies
                .Update(company);
            _context.SaveChanges();
        }

        public void Delete(Company company)
        {
            _context.Companies
                .Remove(company);
            _context.SaveChanges();
        }
    }
}
