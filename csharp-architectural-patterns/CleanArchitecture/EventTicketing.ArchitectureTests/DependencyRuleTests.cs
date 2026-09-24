using EventTicketing.Application.Events;
using EventTicketing.Domain.Events;
using EventTicketing.Infrastructure.Persistence;
using NetArchTest.Rules;
using TestResult = NetArchTest.Rules.TestResult;

namespace EventTicketing.ArchitectureTests;

public class DependencyRuleTests
{
    private const string Application = "EventTicketing.Application";
    private const string Infrastructure = "EventTicketing.Infrastructure";
    private const string Api = "EventTicketing.Api";

    [Fact]
    public void Domain_DependsOnNoOtherLayer()
    {
        var result = Types.InAssembly(typeof(Event).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(Application, Infrastructure, Api)
            .GetResult();

        Assert.True(result.IsSuccessful, Describe(result));
    }

    [Fact]
    public void Application_DoesNotDependOnInfrastructureOrTheWeb()
    {
        var result = Types.InAssembly(typeof(ReserveTicketsHandler).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(Infrastructure, Api, "Microsoft.EntityFrameworkCore", "Microsoft.AspNetCore")
            .GetResult();

        Assert.True(result.IsSuccessful, Describe(result));
    }

    [Fact]
    public void Infrastructure_DoesNotDependOnTheApi()
    {
        var result = Types.InAssembly(typeof(TicketingDbContext).Assembly)
            .ShouldNot()
            .HaveDependencyOn(Api)
            .GetResult();

        Assert.True(result.IsSuccessful, Describe(result));
    }

    private static string Describe(TestResult result) =>
        "Offending types: " + string.Join(", ", result.FailingTypeNames ?? []);
}
