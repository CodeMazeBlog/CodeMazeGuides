using Entities.Helpers;
using Entities.Models;
using System.Linq;
using Xunit;

namespace AccountOwnerServer.Tests;

public class SortHelperTests
{
    private static IQueryable<Owner> Owners() => SqlServerSample.Owners().AsQueryable();

    private static readonly SortHelper<Owner> Sorter = new();

    [Fact]
    public void GivenABlankOrderBy_WhenWeSort_ThenTheQueryIsReturnedUntouched()
    {
        var owners = Owners();

        Assert.Same(owners, Sorter.ApplySort(owners, null));
        Assert.Same(owners, Sorter.ApplySort(owners, "   "));
    }

    [Fact]
    public void GivenOnlyUnknownFields_WhenWeSort_ThenTheQueryIsReturnedUntouchedRatherThanThrowing()
    {
        var owners = Owners();

        var sorted = Sorter.ApplySort(owners, "age");

        Assert.Same(owners, sorted);
    }

    [Fact]
    public void GivenAKnownField_WhenWeSort_ThenTheRowsComeBackInThatOrder()
    {
        var sorted = Sorter.ApplySort(Owners(), "dateOfBirth").ToList();

        Assert.Equal("Anna Bosh", sorted.First().Name);
        Assert.Equal("Nick Somion", sorted.Last().Name);
    }

    [Theory]
    [InlineData("name desc")]
    [InlineData("name DESC")]
    [InlineData("name Desc")]
    public void GivenDescInAnyCasing_WhenWeSort_ThenTheOrderIsDescending(string orderBy)
    {
        var sorted = Sorter.ApplySort(Owners(), orderBy).ToList();

        Assert.Equal("Sam Query", sorted.First().Name);
        Assert.Equal("Anna Bosh", sorted.Last().Name);
    }

    [Fact]
    public void GivenAKnownAndAnUnknownField_WhenWeSort_ThenTheKnownOneStillApplies()
    {
        var sorted = Sorter.ApplySort(Owners(), "age,name desc").ToList();

        Assert.Equal("Sam Query", sorted.First().Name);
    }
}
