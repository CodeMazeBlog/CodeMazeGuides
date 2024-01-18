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
    [Arguments(10)]
    [Arguments(100)]
    public Task<List<Company>> GetCompaniesAsSingleQuery(int count)
    {
        return this._companiesContext.Companies
            .Include(company => company.Products)
            .Include(company => company.Departments)
            .ThenInclude(department => department.Employees)
            .Take(count)
            .AsSingleQuery()
            .ToListAsync();
    }

    [Benchmark]
    [Arguments(10)]
    [Arguments(100)]
    public Task<List<Company>> GetCompaniesAsSplitQuery(int count)
    {
        return this._companiesContext.Companies
            .Include(company => company.Products)
            .Include(company => company.Departments)
            .ThenInclude(department => department.Employees)
            .Take(count)
            .AsSplitQuery()
            .ToListAsync();
    }
}
