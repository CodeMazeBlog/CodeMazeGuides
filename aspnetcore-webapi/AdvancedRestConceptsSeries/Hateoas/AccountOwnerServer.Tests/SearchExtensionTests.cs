using Entities.Models;
using Repository.Extensions;
using System.Linq;
using Xunit;

namespace AccountOwnerServer.Tests;

public class SearchExtensionTests
{
    private static IQueryable<Owner> Owners() => SqlServerSample.Owners().AsQueryable();

    [Fact]
    public void GivenABlankSearchTerm_WhenWeSearch_ThenTheQueryIsReturnedUntouched()
    {
        var owners = Owners();

        Assert.Same(owners, owners.Search(null));
        Assert.Same(owners, owners.Search(string.Empty));
        Assert.Same(owners, owners.Search("   "));
    }

    [Fact]
    public void GivenANameFragment_WhenWeSearch_ThenTheMatchingOwnerComesBack()
    {
        var result = Owners().Search("Anna").ToList();

        Assert.Single(result);
        Assert.Equal("Anna Bosh", result[0].Name);
    }

    [Fact]
    public void GivenAnAddressFragment_WhenWeSearch_ThenTheColumnIsSearchedToo()
    {
        var result = Owners().Search("Wellfield").ToList();

        Assert.Single(result);
        Assert.Equal("John Keen", result[0].Name);
    }

    [Fact]
    public void GivenAPaddedSearchTerm_WhenWeSearch_ThenItIsTrimmedBeforeMatching()
    {
        var result = Owners().Search("  Somion  ").ToList();

        Assert.Single(result);
        Assert.Equal("Nick Somion", result[0].Name);
    }
}
