namespace CountEnumMembers.Tests;
using Xunit;

public class CountEnumMembersTest
{
    [Fact]
    public void WhenGetNamesMethodIsCalled_ThenTotalNumberOfItemsIsReturned()
    {
        var getnames = Enum.GetNames<Seasons>().Length;
        Assert.Equal(4, getnames);
    }

    [Fact]
    public void WhenGetValuesMethodIsCalled_ThenTotalNumberOfValuesIsReturned()
    {
        var getvalues = Enum.GetValues<Seasons>().Length;
        Assert.Equal(4, getvalues);
    }

    [Fact]
    public void WhenGetValuesDistinctMethodIsCalled_ThenTotalNumberOfDistinctValuesIsReturned()
    {
        var distinct_values = Enum.GetValues(typeof(Medals)).Cast<Medals>().Distinct().Count();
        Assert.Equal(2, distinct_values);
    }
}