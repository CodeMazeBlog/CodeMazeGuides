using EventTicketing.Application;
using EventTicketing.Domain;
using NetArchTest.Rules;

namespace EventTicketing.ArchitectureTests;

public class DependencyRuleTests
{
    [Fact]
    public void Domain_DependsOnNoOtherLayer()
    {
        var result = Types.InAssembly(typeof(Event).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny("EventTicketing.Application", "EventTicketing.Infrastructure", "EventTicketing.Api")
            .GetResult();

        Assert.True(result.IsSuccessful, "Offending types: " + string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void Application_DoesNotDependOnInfrastructureOrTheWeb()
    {
        var result = Types.InAssembly(typeof(ReserveTicketsHandler).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny("EventTicketing.Infrastructure", "EventTicketing.Api",
                "Microsoft.EntityFrameworkCore", "Microsoft.AspNetCore")
            .GetResult();

        Assert.True(result.IsSuccessful, "Offending types: " + string.Join(", ", result.FailingTypeNames ?? []));
    }
}
