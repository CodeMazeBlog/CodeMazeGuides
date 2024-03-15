namespace Tests;

public class DateComparerEqualTests
{
    private readonly DateComparer _dateComparer;

    public DateComparerEqualTests()
    {
        _dateComparer = new DateComparer(DateTime.Today.ToString("MM/dd/yyyy"));
    }

    [Fact]
    public void WhenCheckWithComparisonOperatorIsCalledWithEqualDate_ThenReturnsTrue()
    {
        bool result = _dateComparer.CheckWithComparisonOperator();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithCompareToIsCalledWithEqualDate_ThenReturnsTrue()
    {
        bool result = _dateComparer.CheckWithCompareTo();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithDayNumberIsCalledWithEqualDate_ThenReturnsTrue()
    {
        bool result = _dateComparer.CheckWithDayNumber();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithTimeSpanIsCalledWithEqualDate_ThenReturnsTrue()
    {
        bool result = _dateComparer.CheckWithTimeSpan();

        Assert.True(result);
    }
}