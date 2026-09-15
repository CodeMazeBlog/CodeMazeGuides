using Entities.Helpers;
using Entities.Models;
using System.Linq;
using Xunit;

namespace AccountOwnerServer.Tests;

public class DataShaperTests
{
    private static readonly DataShaper<Owner> Shaper = new();

    [Fact]
    public void GivenNoFields_WhenWeShape_ThenEveryPropertyIsKept()
    {
        var shaped = Shaper.ShapeData(SqlServerSample.Owners().First(), null);

        Assert.Equal(4, shaped.Count);
        Assert.True(shaped.ContainsKey(nameof(Owner.Address)));
    }

    [Fact]
    public void GivenASubsetOfFields_WhenWeShape_ThenOnlyThoseComeBack()
    {
        var shaped = Shaper.ShapeData(SqlServerSample.Owners().First(), "name,dateOfBirth");

        Assert.Equal(2, shaped.Count);
        Assert.True(shaped.ContainsKey(nameof(Owner.Name)));
        Assert.False(shaped.ContainsKey(nameof(Owner.Address)));
    }

    [Fact]
    public void GivenAFieldInAnyCasing_WhenWeShape_ThenItStillMatchesThePropertyName()
    {
        var shaped = Shaper.ShapeData(SqlServerSample.Owners().First(), "NAME");

        Assert.True(shaped.ContainsKey(nameof(Owner.Name)));
    }

    [Fact]
    public void GivenAnUnknownField_WhenWeShape_ThenItIsIgnored()
    {
        var shaped = Shaper.ShapeData(SqlServerSample.Owners().First(), "name,age");

        Assert.Single(shaped);
        Assert.True(shaped.ContainsKey(nameof(Owner.Name)));
    }

    [Fact]
    public void GivenACollection_WhenWeShape_ThenEveryEntityIsShaped()
    {
        var shaped = Shaper.ShapeData(SqlServerSample.Owners(), "name").ToList();

        Assert.Equal(5, shaped.Count);
        Assert.All(shaped, s => Assert.Single(s));
    }
}
