using BenchmarkDotNet.Attributes;
using SingleAndSplitQueriesInEFCore.Model;

namespace SingleAndSplitQueriesInEFCore;

[MemoryDiagnoser]
public class SingleAndSplitQueriesBenchmark
{
    private CompaniesContext _dbContext;
    private CompaniesRepository _companiesRepository;

    [IterationSetup]
    public void Setup()
    {
        this._dbContext = new CompaniesContext();
        _companiesRepository = new CompaniesRepository(_dbContext);
    }

    [IterationCleanup]
    public void Cleanup()
    {
        _dbContext.Dispose();
    }

    [Benchmark]
    [IterationCount(100)]
    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsUsingSingleQuery()
    {
        return _companiesRepository.GetCompaniesWithDepartmentsUsingSingleQuery();
    }

    [Benchmark]
    [IterationCount(100)]
    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsAndProductsUsingSingleQuery()
    {
        return _companiesRepository.GetCompaniesWithDepartmentsAndProductsUsingSingleQuery();
    }

    [Benchmark]
    [IterationCount(100)]
    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsUsingSplitQuery()
    {
        return _companiesRepository.GetCompaniesWithDepartmentsUsingSplitQuery();
    }

    [Benchmark]
    [IterationCount(100)]
    public IReadOnlyCollection<Company> GetCompaniesWithDepartmentsAndProductsUsingSplitQuery()
    {
        return _companiesRepository.GetCompaniesWithDepartmentsAndProductsUsingSplitQuery();
    }
}
