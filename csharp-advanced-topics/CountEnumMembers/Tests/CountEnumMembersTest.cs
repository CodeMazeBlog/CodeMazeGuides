namespace CountEnumMembers.Tests;
using Xunit;

public class CountEnumMembersTest
{
    [Fact]
    public void WhenGetNamesMethodIsCalled_ThenTotalNumberOfItemsIsReturned()
    {
        var getNames = Enum.GetNames<Seasons>().Length;
        Assert.Equal(4, getNames);
    }

    [Fact]
    public void WhenGetValuesMethodIsCalled_ThenTotalNumberOfValuesIsReturned()
    {
        var getValues = Enum.GetValues<Seasons>().Length;
        Assert.Equal(4, getValues);
    }

    [Fact]
    public void WhenGetValuesDistinctMethodIsCalled_ThenTotalNumberOfDistinctValuesIsReturned()
    {
        var distinctValues = Enum.GetValues(typeof(Medals)).Cast<Medals>().Distinct().Count();
        Assert.Equal(2, distinctValues);
    }
}