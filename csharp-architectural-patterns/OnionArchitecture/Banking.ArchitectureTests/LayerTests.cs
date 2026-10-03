using Banking.Api;
using Banking.Domain;
using Banking.Services;
using NetArchTest.Rules;

namespace Banking.ArchitectureTests;

public class LayerTests
{
    [Fact]
    public void Domain_DependsOnNoOtherLayer()
    {
        var result = Types.InAssembly(typeof(Account).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny("Banking.Services", "Banking.Infrastructure", "Banking.Api")
            .GetResult();

        Assert.True(result.IsSuccessful, "Offending types: " + string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void Services_DoNotDependOnTheOuterRing()
    {
        var result = Types.InAssembly(typeof(IAccountService).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny("Banking.Infrastructure", "Banking.Api",
                "Microsoft.EntityFrameworkCore", "Microsoft.AspNetCore")
            .GetResult();

        Assert.True(result.IsSuccessful, "Offending types: " + string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void Endpoints_GoThroughTheServices()
    {
        var result = Types.InAssembly(typeof(AccountEndpoints).Assembly)
            .That()
            .ResideInNamespace("Banking.Api")
            .ShouldNot()
            .HaveDependencyOnAny("Banking.Infrastructure", "Banking.Domain.IAccountRepository")
            .GetResult();

        Assert.True(result.IsSuccessful, "Offending types: " + string.Join(", ", result.FailingTypeNames ?? []));
    }
}
