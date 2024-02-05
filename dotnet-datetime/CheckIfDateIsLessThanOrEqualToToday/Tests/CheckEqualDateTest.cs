namespace Tests;

public class CheckEqualDateTest
{
    private readonly CheckDateMethods _checkDateMethod;

    public CheckEqualDateTest()
    {
        _checkDateMethod = new CheckDateMethods(DateTime.Today.ToString("MM/dd/yyyy"));
    }

    [Fact]
    public void WhenCheckWithComparisonOperatorIsCalledWithEqualDate_ThenReturnsTrue()
    {
        bool result = _checkDateMethod.CheckWithComparisonOperator();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithCompareIsCalledWithEqualDate_ThenReturnsTrue()
    {
        bool result = _checkDateMethod.CheckWithCompare();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithCompareToIsCalledWithEqualDate_ThenReturnsTrue()
    {
        bool result = _checkDateMethod.CheckWithCompareTo();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithTimeSpanIsCalledWithEqualDate_ThenReturnsTrue()
    {
        bool result = _checkDateMethod.CheckWithTimeSpan();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithLINQIsCalledWithLesserDate_ThenReturnsTrue()
    {
        bool result = _checkDateMethod.CheckWithLINQ();

        Assert.True(result);
    }
}