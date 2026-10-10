using EventTicketing.Features.Reservations;
using NetArchTest.Rules;

namespace EventTicketing.Tests;

public class SliceTests
{
    [Fact]
    public void Features_DoNotDependOnEachOther()
    {
        var assembly = typeof(ReserveTickets).Assembly;

        var features = assembly.GetTypes()
            .Select(t => t.Namespace)
            .OfType<string>()
            .Where(ns => ns.StartsWith("EventTicketing.Features."))
            .Distinct()
            .ToArray();

        foreach (var feature in features)
        {
            var otherFeatures = features.Where(f => f != feature).ToArray();

            var result = Types.InAssembly(assembly)
                .That()
                .ResideInNamespace(feature)
                .ShouldNot()
                .HaveDependencyOnAny(otherFeatures)
                .GetResult();

            Assert.True(result.IsSuccessful,
                $"{feature} depends on another feature: " + string.Join(", ", result.FailingTypeNames ?? []));
        }
    }
}
