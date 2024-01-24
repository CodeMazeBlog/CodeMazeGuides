using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using SingleAndSplitQueriesInEFCore.Model;

namespace SingleAndSplitQueriesInEFCore;

[MemoryDiagnoser]
public class SingleAndSplitBenchmark
{
    private CompaniesContext _companiesContext;

    [IterationSetup]
    public void Setup()
    {
        _companiesContext = new CompaniesContext();
    }

    [IterationCleanup]
    public void Cleanup()
    {
        _companiesContext.Dispose();
    }

    [Benchmark]
    [IterationCount(100)]
    public Task<List<Company>> GetCompaniesWithDepartmentsUsingSingleQuery()
    {
        return _companiesContext.Companies
            .Include(company => company.Departments)
            .ToListAsync();
    }

    [Benchmark]
    [IterationCount(100)]
    public Task<List<Company>> GetCompaniesWithDepartmentsAndProductsUsingSingleQuery()
    {
        return _companiesContext.Companies
            .Include(company => company.Products)
            .Include(company => company.Departments)
            .ToListAsync();
    }

    [Benchmark]
    [IterationCount(100)]
    public Task<List<Company>> GetCompaniesWithDepartmentsUsingSplitQuery()
    {
        return _companiesContext.Companies
            .Include(company => company.Departments)
            .AsSplitQuery()
            .ToListAsync();
    }

    [Benchmark]
    [IterationCount(100)]
    public Task<List<Company>> GetCompaniesWithDepartmentsAndProductsUsingSplitQuery()
    {
        return _companiesContext.Companies
            .Include(company => company.Products)
            .Include(company => company.Departments)
            .AsSplitQuery()
            .ToListAsync();
    }
}
