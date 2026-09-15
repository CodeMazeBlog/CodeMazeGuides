using Entities.Helpers;
using Entities.Models;
using Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AccountOwnerServer.Tests;

/// <summary>
/// These run against a real SQL Server started by Testcontainers. They are skipped unless
/// CODEMAZE_SQLSERVER_TESTS=1 is set, because the SQL Server image is not guaranteed to be
/// available on every machine or CI runner.
/// </summary>
public class OwnerRepositorySqlServerTests
{
    [SqlServerFact]
    public async Task GivenAPageSizeOfTwo_WhenWeAskForTheSecondPage_ThenWeGetTwoOwnersAndTheRightMetadata()
    {
        await using var sample = await SqlServerSample.StartAsync();
        await using var context = sample.CreateContext();

        var repository = new OwnerRepository(context);

        var owners = await repository.GetOwners(new OwnerParameters { PageNumber = 2, PageSize = 2 });

        Assert.Equal(2, owners.Count);
        Assert.Equal(5, owners.TotalCount);
        Assert.Equal(3, owners.TotalPages);
        Assert.True(owners.HasPrevious);
        Assert.True(owners.HasNext);
    }

    [SqlServerFact]
    public async Task GivenTheSameMinAndMaxYear_WhenWeFilter_ThenTheOwnerBornInThatYearComesBack()
    {
        await using var sample = await SqlServerSample.StartAsync();
        await using var context = sample.CreateContext();

        var repository = new OwnerRepository(context);

        var owners = await repository.GetOwners(new OwnerParameters
        {
            MinYearOfBirth = 1990,
            MaxYearOfBirth = 1990
        });

        Assert.Equal(1, owners.TotalCount);
        Assert.Equal("Sam Query", NameOf(owners.Single()));
    }

    [SqlServerFact]
    public async Task GivenOnlyAMinimumYear_WhenWeFilter_ThenTheUpperBoundIsOpen()
    {
        await using var sample = await SqlServerSample.StartAsync();
        await using var context = sample.CreateContext();

        var repository = new OwnerRepository(context);

        var owners = await repository.GetOwners(new OwnerParameters { MinYearOfBirth = 1990 });

        Assert.Equal(2, owners.TotalCount);
    }

    private static string NameOf(Owner owner) => owner.Name;
}
