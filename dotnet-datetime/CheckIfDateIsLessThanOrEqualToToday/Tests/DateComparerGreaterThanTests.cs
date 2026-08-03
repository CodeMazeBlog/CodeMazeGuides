namespace Tests;

public class DateComparerGreaterThanTests
{
    private readonly DateComparer _dateComparer;

    public DateComparerGreaterThanTests()
    {
        _dateComparer = new DateComparer(DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"));
    }

    [Fact]
    public void WhenCheckWithComparisonOperatorIsCalledWithGreaterDate_ThenReturnsFalse()
    {
        bool result = _dateComparer.CheckWithComparisonOperator();

        Assert.False(result);
    }

    [Fact]
    public void WhenCheckWithCompareToIsCalledWithGreaterDate_ThenReturnsFalse()
    {
        bool result = _dateComparer.CheckWithCompareTo();

        Assert.False(result);
    }

    [Fact]
    public void WhenCheckWithDayNumberIsCalledWithGreaterDate_ThenReturnsFalse()
    {
        bool result = _dateComparer.CheckWithDayNumber();

        Assert.False(result);
    }

    [Fact]
    public void WhenCheckWithTimeSpanIsCalledWithGreaterDate_ThenReturnsFalse()
    {
        bool result = _dateComparer.CheckWithTimeSpan();

        Assert.False(result);
    }
}