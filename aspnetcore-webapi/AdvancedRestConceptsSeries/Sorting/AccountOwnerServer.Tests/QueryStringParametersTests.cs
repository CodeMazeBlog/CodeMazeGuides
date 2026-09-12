using Entities.Models;
using Xunit;

namespace AccountOwnerServer.Tests;

public class QueryStringParametersTests
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(-3, 1)]
    [InlineData(2, 2)]
    public void GivenAPageNumber_WhenItIsSet_ThenItNeverDropsBelowOne(int requested, int expected)
    {
        var parameters = new OwnerParameters { PageNumber = requested };

        Assert.Equal(expected, parameters.PageNumber);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(-10, 1)]
    [InlineData(7, 7)]
    [InlineData(500, 50)]
    public void GivenAPageSize_WhenItIsSet_ThenItIsClampedBetweenOneAndFifty(int requested, int expected)
    {
        var parameters = new OwnerParameters { PageSize = requested };

        Assert.Equal(expected, parameters.PageSize);
    }

    [Fact]
    public void GivenNoQueryString_WhenParametersAreCreated_ThenTheDefaultsAreOneAndTen()
    {
        var parameters = new OwnerParameters();

        Assert.Equal(1, parameters.PageNumber);
        Assert.Equal(10, parameters.PageSize);
    }
}
