using Entities.Models;
using Xunit;

namespace AccountOwnerServer.Tests;

public class OwnerParametersTests
{
    [Fact]
    public void GivenTheSameMinAndMaxYear_WhenTheRangeIsValidated_ThenItIsAccepted()
    {
        var parameters = new OwnerParameters { MinYearOfBirth = 1990, MaxYearOfBirth = 1990 };

        Assert.True(parameters.ValidYearRange);
    }

    [Fact]
    public void GivenAMaxYearBelowTheMinYear_WhenTheRangeIsValidated_ThenItIsRejected()
    {
        var parameters = new OwnerParameters { MinYearOfBirth = 1975, MaxYearOfBirth = 1974 };

        Assert.False(parameters.ValidYearRange);
    }

    [Fact]
    public void GivenNoYearsAtAll_WhenTheRangeIsValidated_ThenItIsAccepted()
    {
        var parameters = new OwnerParameters();

        Assert.Null(parameters.MinYearOfBirth);
        Assert.Null(parameters.MaxYearOfBirth);
        Assert.True(parameters.ValidYearRange);
    }

    [Fact]
    public void GivenOnlyAMinYear_WhenTheRangeIsValidated_ThenItIsAccepted()
    {
        var parameters = new OwnerParameters { MinYearOfBirth = 1975 };

        Assert.True(parameters.ValidYearRange);
    }
}
