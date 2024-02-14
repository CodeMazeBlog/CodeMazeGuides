using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using SingleAndSplitQueriesInEFCore.Model;

namespace SingleAndSplitQueriesInEFCore;

[MemoryDiagnoser]
[IterationCount(100)]
[HideColumns(Column.StdDev, Column.Gen2)]
public class SingleAndSplitQueriesBenchmark
{
    private CompaniesContext _dbContext = null!;
    private CompaniesRepository _companiesRepository = null!;

    [GlobalSetup]
    public void Setup()
    {
        _dbContext = new CompaniesContext();
        _companiesRepository = new CompaniesRepository(_dbContext);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _dbContext.Dispose();
    }

    [Benchmark]
    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsUsingSingleQuery()
    {
        return _companiesRepository.GetCompaniesWithDepartmentsUsingSingleQuery();
    }

    [Benchmark]
    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsAndProductsUsingSingleQuery()
    {
        return _companiesRepository.GetCompaniesWithDepartmentsAndProductsUsingSingleQuery();
    }

    [Benchmark]
    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsUsingSplitQuery()
    {
        return _companiesRepository.GetCompaniesWithDepartmentsUsingSplitQuery();
    }

    [Benchmark]
    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsAndProductsUsingSplitQuery()
    {
        return _companiesRepository.GetCompaniesWithDepartmentsAndProductsUsingSplitQuery();
    }
}
