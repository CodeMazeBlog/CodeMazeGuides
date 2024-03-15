using Microsoft.EntityFrameworkCore;
using SingleAndSplitQueriesInEFCore.Model;

namespace SingleAndSplitQueriesInEFCore;

public sealed class CompaniesRepository(CompaniesContext dbContext)
{
    private readonly CompaniesContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsUsingSingleQuery()
    {
        return _dbContext.Companies
            .Include(company => company.Departments)
            .ToList();
    }

    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsAndProductsUsingSingleQuery()
    {
        return _dbContext.Companies
            .Include(company => company.Products)
            .Include(company => company.Departments)
            .ToList();
    }

    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsUsingSplitQuery()
    {
        return _dbContext.Companies
            .Include(company => company.Departments)
            .AsSplitQuery()
            .ToList();
    }

    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsAndProductsUsingSplitQuery()
    {
        return _dbContext.Companies
            .Include(company => company.Products)
            .Include(company => company.Departments)
            .AsSplitQuery()
            .ToList();
    }
}
