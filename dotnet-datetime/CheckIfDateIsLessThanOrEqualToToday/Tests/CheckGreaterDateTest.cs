namespace Tests;

public class CheckGreaterDateTest
{
    private readonly CheckDateMethods _checkDateMethod;

    public CheckGreaterDateTest()
    {
        _checkDateMethod = new CheckDateMethods(DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"));
    }

    [Fact]
    public void WhenCheckWithComparisonOperatorIsCalledWithGreaterDate_ThenReturnsFalse()
    {
        bool result = _checkDateMethod.CheckWithComparisonOperator();

        Assert.False(result);
    }

    [Fact]
    public void WhenCheckWithCompareIsCalledWithGreaterDate_ThenReturnsFalse()
    {
        bool result = _checkDateMethod.CheckWithCompare();

        Assert.False(result);
    }

    [Fact]
    public void WhenCheckWithCompareToIsCalledWithGreaterDate_ThenReturnsFalse()
    {
        bool result = _checkDateMethod.CheckWithCompareTo();

        Assert.False(result);
    }

    [Fact]
    public void WhenCheckWithTimeSpanIsCalledWithGreaterDate_ThenReturnsFalse()
    {
        bool result = _checkDateMethod.CheckWithTimeSpan();

        Assert.False(result);
    }

    [Fact]
    public void WhenCheckWithLINQIsCalledWithLesserDate_ThenReturnsFalse()
    {
        bool result = _checkDateMethod.CheckWithLINQ();

        Assert.False(result);
    }
}