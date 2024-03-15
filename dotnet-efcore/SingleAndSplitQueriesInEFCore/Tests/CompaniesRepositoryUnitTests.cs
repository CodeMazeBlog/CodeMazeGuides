using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SingleAndSplitQueriesInEFCore;
using Xunit;

namespace Tests;

public class CompaniesRepositoryUnitTests : IDisposable
{
    private readonly CompaniesContext _dbContext;

    public CompaniesRepositoryUnitTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<CompaniesContext>()
            .UseInMemoryDatabase("SingleAndSplitQueriesInEFCoreTest")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        _dbContext = new CompaniesContext(optionsBuilder);
        _dbContext.Database.EnsureCreated();
    }

    [Fact]
    public void WhenGettingCompaniesWithDepartmentsUsingSingleQuery_ThenCompanyDepartmentsAreNotEmpty()
    {
        var repository = new CompaniesRepository(_dbContext);

        var companies = repository.GetCompaniesWithDepartmentsUsingSingleQuery();

        Assert.NotEmpty(companies);
        Assert.Equal(1000, companies.Count);
        Assert.All(companies, company => Assert.NotEmpty(company.Departments));
        Assert.All(companies, company => Assert.Equal(10, company.Departments.Count));
        Assert.All(companies, company => Assert.Empty(company.Products));
    }

    [Fact]
    public void WhenGettingCompaniesWithDepartmentsAndProductsUsingSingleQuery_ThenCompanyDepartmentsAndProductsAreNotEmpty()
    {
        var repository = new CompaniesRepository(_dbContext);

        var companies = repository.GetCompaniesWithDepartmentsAndProductsUsingSingleQuery();

        Assert.NotEmpty(companies);
        Assert.Equal(1000, companies.Count);
        Assert.All(companies, company => Assert.NotEmpty(company.Departments));
        Assert.All(companies, company => Assert.Equal(10, company.Departments.Count));
        Assert.All(companies, company => Assert.NotEmpty(company.Products));
        Assert.All(companies, company => Assert.Equal(10, company.Products.Count));
    }

    [Fact]
    public void WhenGettingCompaniesWithDepartmentsUsingSplitQuery_ThenCompanyDepartmentsAreNotEmpty()
    {
        var repository = new CompaniesRepository(_dbContext);

        var companies = repository.GetCompaniesWithDepartmentsUsingSplitQuery();

        Assert.NotEmpty(companies);
        Assert.Equal(1000, companies.Count);
        Assert.All(companies, company => Assert.NotEmpty(company.Departments));
        Assert.All(companies, company => Assert.Equal(10, company.Departments.Count));
        Assert.All(companies, company => Assert.Empty(company.Products));
    }

    [Fact]
    public void WhenGettingCompaniesWithDepartmentsAndProductsUsingSplitQuery_ThenCompanyDepartmentsAndProductsAreNotEmpty()
    {
        var repository = new CompaniesRepository(_dbContext);

        var companies = repository.GetCompaniesWithDepartmentsAndProductsUsingSplitQuery();

        Assert.NotEmpty(companies);
        Assert.Equal(1000, companies.Count);
        Assert.All(companies, company => Assert.NotEmpty(company.Departments));
        Assert.All(companies, company => Assert.Equal(10, company.Departments.Count));
        Assert.All(companies, company => Assert.NotEmpty(company.Products));
        Assert.All(companies, company => Assert.Equal(10, company.Products.Count));
    }

    public void Dispose()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Dispose();
    }
}
