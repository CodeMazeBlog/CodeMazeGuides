using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Linq;
using Xunit;

namespace DateOnlyAndTimeOnlyTypes.Tests;

public class DateOnlyAndTimeOnlyTypesTest
{
    private static AppDbContext CreateSqlServerContext()
    {
        // No connection is opened: these tests only build the model and generate SQL.
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=.;Database=DateOnlyDemo;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void GivenDbContext_WhenSavingDateOnlyTimeOnlyValues_ThenReadsThemBack()
    {
        var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("DateOnlyDemo")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        using var context = new AppDbContext(contextOptions);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var employee = new Employee
        {
            Name = "John Doe",
            BirthDate = new DateOnly(2023, 5, 9),
            WorkStartTime = new TimeOnly(8, 30),
            WorkEndTime = new TimeOnly(16, 30)
        };

        context.Employees.Add(employee);
        context.SaveChanges();

        var storedEmployee = context.Employees.Find(employee.Id);

        Assert.NotNull(storedEmployee);
        Assert.Equal(employee.BirthDate, storedEmployee!.BirthDate);
        Assert.Equal(employee.WorkStartTime, storedEmployee.WorkStartTime);
        Assert.Equal(employee.WorkEndTime, storedEmployee.WorkEndTime);
    }

    [Fact]
    public void GivenSqlServerProvider_WhenGeneratingSchema_ThenMapsDateOnlyToDateAndTimeOnlyToTime()
    {
        using var context = CreateSqlServerContext();

        var script = context.Database.GenerateCreateScript();

        Assert.Contains("[BirthDate] date NOT NULL", script);
        Assert.Contains("[WorkStartTime] time NOT NULL", script);
        Assert.Contains("[WorkEndTime] time NOT NULL", script);
    }

    [Fact]
    public void GivenDateOnlyMember_WhenFiltering_ThenTranslatesToSql()
    {
        using var context = CreateSqlServerContext();

        var sql = context.Employees
            .Where(e => e.BirthDate.Year == 1990 && e.WorkStartTime.Hour < 9)
            .ToQueryString();

        Assert.Contains("DATEPART(year, [e].[BirthDate]) = 1990", sql);
        Assert.Contains("DATEPART(hour, [e].[WorkStartTime]) < 9", sql);
    }

    [Fact]
    public void GivenLegacyDatetime2Column_WhenUsingConverter_ThenKeepsDatetime2()
    {
        var options = new DbContextOptionsBuilder<LegacyAppDbContext>()
            .UseSqlServer("Server=.;Database=LegacyDemo;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;

        using var context = new LegacyAppDbContext(options);

        var script = context.Database.GenerateCreateScript();

        Assert.Contains("[BirthDate] datetime2 NOT NULL", script);
    }
}
