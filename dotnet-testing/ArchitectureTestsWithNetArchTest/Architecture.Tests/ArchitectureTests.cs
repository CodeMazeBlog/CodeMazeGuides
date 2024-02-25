namespace Architecture.Tests;

public class ArchitectureTests
{
    [Fact]
    public void PersistenceLayerClasses_ShouldNot_BeInheritable()
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
    public void ServiceLayerInterfaces_Should_BePublic()
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
    public void DomainLayer_ShouldNot_HaveAnyDependencies()
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
    public void CatNotFoundException_Should_InheritFromNotFoundException()
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
    public void ServiceInterfaces_Should_BePublic_And_BeInterfaces_And_StartWithI()
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
    public void ServiceInterfaces_Should_MeetCustomRule_And_ServiceManager_Should_HaveDependencyOnContracts()
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