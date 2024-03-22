namespace Architecture.Tests;

public class ArchitectureTests
{
    [Fact]
    public void GivenPersistenceLayerClasses_WhenInheritanceIsAttempted_ThenItShouldNotBePossible()
    {
        // Arrange
        var persistenceLayerAssembly = typeof(CatsDbContext).Assembly;

        // Act
        var result = Types.InAssembly(persistenceLayerAssembly)
            .Should().BeSealed()
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void GivenServiceLayerInterfaces_WhenAccessedFromOtherProjects_ThenTheyAreVisible()
    {
        // Arrange
        var serviceLayerAssembly = typeof(IServiceManager).Assembly;

        // Act
        var result = Types.InAssembly(serviceLayerAssembly)
            .Should().BePublic()
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void GivenDomainLayer_ThenShouldNotHaveAnyDependencies()
    {
        // Arrange
        var domainLayerAssembly = typeof(Cat).Assembly;

        // Act
        var result = Types.InAssembly(domainLayerAssembly)
            .ShouldNot().HaveDependencyOnAll(
                ["Api", "Contracts", "Persistence", "Services", "Services.Abstractions"])
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void GivenCatNotFoundException_ThenShouldInheritFromNotFoundException()
    {
        // Arrange
        var domainLayerAssembly = typeof(CatNotFoundException).Assembly;

        // Act
        var result = Types.InAssembly(domainLayerAssembly)
            .That().ResideInNamespace("Domain.Exceptions")
            .And().HaveNameStartingWith("Cat")
            .Should().Inherit(typeof(NotFoundException))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void GivenServiceInterfaces_ThenShouldBePublicAndBeInterfacesAndStartWithI()
    {
        // Arrange
        var serviceLayerAssembly = typeof(IServiceManager).Assembly;
        var myCustomRule = new CustomServiceLayerRule();

        // Act
        var result = Types.InAssembly(serviceLayerAssembly)
            .Should().MeetCustomRule(myCustomRule)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void GivenServiceInterfaces_ThenShouldMeetCustomRuleAndServiceManagerShouldHaveDependencyOnContracts()
    {
        // Arrange
        var serviceLayerAssembly = typeof(IServiceManager).Assembly;
        var myCustomRule = new CustomServiceLayerRule();

        var customPolicy = Policy.Define(
                "Service Interfaces Policy",
                "This policy ensures that all types meet the given conditions")
            .For(Types.InAssembly(serviceLayerAssembly))
            .Add(types => types
                .Should().MeetCustomRule(myCustomRule))
            .Add(types => types
                .That().HaveNameEndingWith("Manager")
                .ShouldNot().HaveDependencyOn("Contracts")
            );

        // Act
        var results = customPolicy.Evaluate();

        // Assert
        foreach (var result in results.Results)
        {
            result.IsSuccessful.Should().BeTrue();
        }
    }
}