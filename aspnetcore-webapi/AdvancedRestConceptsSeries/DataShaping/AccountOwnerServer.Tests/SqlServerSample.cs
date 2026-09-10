using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testcontainers.MsSql;

namespace AccountOwnerServer.Tests;

/// <summary>
/// A throwaway SQL Server container seeded with the five owners and eight accounts the
/// articles use. Each test owns its own container, so nothing is created when the tests
/// are skipped.
/// </summary>
public sealed class SqlServerSample : IAsyncDisposable
{
    private readonly MsSqlContainer _container;

    private SqlServerSample(MsSqlContainer container)
    {
        _container = container;
    }

    public static async Task<SqlServerSample> StartAsync()
    {
        var container = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-latest").Build();
        await container.StartAsync();

        var sample = new SqlServerSample(container);

        await using var context = sample.CreateContext();
        await context.Database.EnsureCreatedAsync();

        context.Owners.AddRange(Owners());
        context.Accounts.AddRange(Accounts());
        await context.SaveChangesAsync();

        return sample;
    }

    public RepositoryContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(_container.GetConnectionString())
            .Options;

        return new RepositoryContext(options);
    }

    public async ValueTask DisposeAsync() => await _container.DisposeAsync();

    public static List<Owner> Owners() =>
    [
        new() { Id = Guid.Parse("24fd81f8-d58a-4bcc-9f35-dc6cd5641906"), Name = "John Keen", DateOfBirth = new DateTime(1980, 12, 5), Address = "61 Wellfield Road" },
        new() { Id = Guid.Parse("261e1685-cf26-494c-b17c-3546e65f5620"), Name = "Anna Bosh", DateOfBirth = new DateTime(1974, 11, 14), Address = "27 Colored Row" },
        new() { Id = Guid.Parse("66774006-2371-4d5b-8518-2177bcf3f73e"), Name = "Nick Somion", DateOfBirth = new DateTime(1998, 12, 15), Address = "North sunny address 102" },
        new() { Id = Guid.Parse("a3c1880c-674c-4d18-8f91-5d3608a2c937"), Name = "Sam Query", DateOfBirth = new DateTime(1990, 4, 22), Address = "91 Western Roads" },
        new() { Id = Guid.Parse("f98e4d74-0f68-4aac-89fd-047f1aaca6b6"), Name = "Martin Miller", DateOfBirth = new DateTime(1983, 5, 21), Address = "3 Edgar Buildings" }
    ];

    public static List<Account> Accounts() =>
    [
        new() { Id = Guid.Parse("03e91478-5608-4132-a753-d494dafce00b"), DateCreated = new DateTime(2003, 12, 15), AccountType = "Domestic", OwnerId = Guid.Parse("f98e4d74-0f68-4aac-89fd-047f1aaca6b6") },
        new() { Id = Guid.Parse("356a5a9b-64bf-4de0-bc84-5395a1fdc9c4"), DateCreated = new DateTime(1996, 2, 15), AccountType = "Domestic", OwnerId = Guid.Parse("261e1685-cf26-494c-b17c-3546e65f5620") },
        new() { Id = Guid.Parse("371b93f2-f8c5-4a32-894a-fc672741aa5b"), DateCreated = new DateTime(1999, 5, 4), AccountType = "Domestic", OwnerId = Guid.Parse("24fd81f8-d58a-4bcc-9f35-dc6cd5641906") },
        new() { Id = Guid.Parse("670775db-ecc0-4b90-a9ab-37cd0d8e2801"), DateCreated = new DateTime(1999, 12, 21), AccountType = "Savings", OwnerId = Guid.Parse("24fd81f8-d58a-4bcc-9f35-dc6cd5641906") },
        new() { Id = Guid.Parse("a3fbad0b-7f48-4feb-8ac0-6d3bbc997bfc"), DateCreated = new DateTime(2010, 5, 28), AccountType = "Domestic", OwnerId = Guid.Parse("a3c1880c-674c-4d18-8f91-5d3608a2c937") },
        new() { Id = Guid.Parse("aa15f658-04bb-4f73-82af-82db49d0fbef"), DateCreated = new DateTime(1999, 5, 12), AccountType = "Foreign", OwnerId = Guid.Parse("24fd81f8-d58a-4bcc-9f35-dc6cd5641906") },
        new() { Id = Guid.Parse("c6066eb0-53ca-43e1-97aa-3c2169eec659"), DateCreated = new DateTime(1996, 2, 16), AccountType = "Foreign", OwnerId = Guid.Parse("261e1685-cf26-494c-b17c-3546e65f5620") },
        new() { Id = Guid.Parse("eccadf79-85fe-402f-893c-32d3f03ed9b1"), DateCreated = new DateTime(2010, 6, 20), AccountType = "Foreign", OwnerId = Guid.Parse("a3c1880c-674c-4d18-8f91-5d3608a2c937") }
    ];
}
