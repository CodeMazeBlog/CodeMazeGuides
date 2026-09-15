using Entities.Helpers;
using Entities.Models;
using System;
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

        Assert.Equal(4, shaped.Entity.Count);
        Assert.True(shaped.Entity.ContainsKey(nameof(Owner.Address)));
    }

    [Fact]
    public void GivenASubsetOfFields_WhenWeShape_ThenOnlyThoseComeBack()
    {
        var shaped = Shaper.ShapeData(SqlServerSample.Owners().First(), "name,dateOfBirth");

        Assert.Equal(2, shaped.Entity.Count);
        Assert.True(shaped.Entity.ContainsKey(nameof(Owner.Name)));
        Assert.False(shaped.Entity.ContainsKey(nameof(Owner.Address)));
    }

    [Fact]
    public void GivenAnUnknownField_WhenWeShape_ThenItIsIgnored()
    {
        var shaped = Shaper.ShapeData(SqlServerSample.Owners().First(), "name,age");

        Assert.Single(shaped.Entity);
        Assert.True(shaped.Entity.ContainsKey(nameof(Owner.Name)));
    }

    [Fact]
    public void GivenAShapedEntity_WhenTheIdIsNotAmongTheFields_ThenItIsStillCarriedOutsideThePayload()
    {
        var owner = SqlServerSample.Owners().First();

        var shaped = Shaper.ShapeData(owner, "name");

        Assert.Equal(owner.Id, shaped.Id);
        Assert.False(shaped.Entity.ContainsKey(nameof(Owner.Id)));
    }

    [Fact]
    public void GivenACollection_WhenWeShape_ThenEveryEntityIsShaped()
    {
        var shaped = Shaper.ShapeData(SqlServerSample.Owners(), "name").ToList();

        Assert.Equal(5, shaped.Count);
        Assert.All(shaped, s => Assert.Single(s.Entity));
        Assert.All(shaped, s => Assert.NotEqual(Guid.Empty, s.Id));
    }
}
