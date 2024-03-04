namespace Tests;

public class DateComparerLessThanTests
{
    private readonly DateComparer _dateComparer;

    public DateComparerLessThanTests()
    {
        _dateComparer = new DateComparer(DateTime.Today.AddDays(-1).ToString("MM/dd/yyyy"));
    }

    [Fact]
    public void WhenCheckWithComparisonOperatorIsCalledWithLesserDate_ThenReturnsTrue()
    {
        bool result = _dateComparer.CheckWithComparisonOperator();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithCompareToIsCalledWithLesserDate_ThenReturnsTrue()
    {
        bool result = _dateComparer.CheckWithCompareTo();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithDayNumberIsCalledWithLesserDate_ThenReturnsTrue()
    {
        bool result = _dateComparer.CheckWithDayNumber();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithTimeSpanIsCalledWithLesserDate_ThenReturnsTrue()
    {
        bool result = _dateComparer.CheckWithTimeSpan();

        Assert.True(result);
    }
}