namespace Tests;

public class CheckLesserDateTest
{
    private readonly CheckDateMethods _checkDateMethod;

    public CheckLesserDateTest()
    {
        _checkDateMethod = new CheckDateMethods(DateTime.Today.AddDays(-1).ToString("MM/dd/yyyy"));
    }

    [Fact]
    public void WhenCheckWithComparisonOperatorIsCalledWithLesserDate_ThenReturnsTrue()
    {
        bool result = _checkDateMethod.CheckWithComparisonOperator();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithCompareIsCalledWithLesserDate_ThenReturnsTrue()
    {
        bool result = _checkDateMethod.CheckWithCompare();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithCompareToIsCalledWithLesserDate_ThenReturnsTrue()
    {
        bool result = _checkDateMethod.CheckWithCompareTo();

        Assert.True(result);
    }

    [Fact]
    public void WhenCheckWithTimeSpanIsCalledWithLesserDate_ThenReturnsTrue()
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