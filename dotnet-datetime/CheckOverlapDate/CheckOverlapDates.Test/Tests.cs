namespace CheckOverlapDates.Test;

public class Tests
{
    [Theory]
    [MemberData(nameof(DontOverlapDateRanges))]
    public void GivenTwoDateRanges_WhenUsingOverlapCheckerClass_ThenReturnFalseIfTheyOverlap(DateRange firstDateRange, DateRange secondDateRange)
    {
        var result = OverlapChecker.Overlap(firstDateRange.Start, firstDateRange.End, secondDateRange.Start, secondDateRange.End);

        Assert.False(result);
    }

    [Theory]
    [MemberData(nameof(OverlapDateRanges))]
    public void GivenTwoDateRanges_WhenUsingOverlapCheckerClass_ThenReturnTrueIfTheyOverlap(DateRange firstDateRange, DateRange secondDateRange)
    {
        var result = OverlapChecker.Overlap(firstDateRange.Start, firstDateRange.End, secondDateRange.Start, secondDateRange.End);

        Assert.True(result);
    }

    [Theory]
    [MemberData(nameof(DontOverlapDateRanges))]
    public void GivenTwoDateRanges_WhenUsingDateRangeClass_ThanReturnFalseIfTheyOverlap(DateRange firstDateRange, DateRange secondDateRange)
    {
        var result = firstDateRange.Overlap(secondDateRange);

        Assert.False(result);
    }

    [Theory]
    [MemberData(nameof(OverlapDateRanges))]
    public void GivenTwoDateRanges_WhenUsingDateRangeClass_ThenReturnTrueIfTheyOverlap(DateRange firstDateRange, DateRange secondDateRange)
    {
        var result = firstDateRange.Overlap(secondDateRange);

        Assert.True(result);
    }

    public static IEnumerable<object[]> DontOverlapDateRanges()
    {
        //The first date range starts 2023-01-10 and ends 2023-01-11
        //The second date range starts 2023-01-12 and ends 2023-01-13.
        yield return new object[]
        {
            new DateRange(new(2023, 01, 10), new(2023, 01, 11)),
            new DateRange(new(2023, 01, 12), new(2023, 01, 13))
        };

        //The first daterange starts 2023-01-12 and ends 2023-01-13
        //The second daterange starts 2023-01-10 and ends 2023-01-11.
        yield return new object[]
        {
            new DateRange(new(2023, 01, 12), new(2023, 01, 13)),
            new DateRange(new(2023, 01, 10), new(2023, 01, 11))
        };
    }

    public static IEnumerable<object[]> OverlapDateRanges()
    {
        //The first date range starts 2023-01-10 and ends 2023-01-12
        //The second daterange starts 2023,01-05 abd ends 2023-01-17
        yield return new object[]
        {
            new DateRange(new(2023, 01, 10), new(2023, 01, 12)),
            new DateRange(new(2023, 01, 05), new(2023, 01, 17))
        };

        //The first date range starts 2023-01-05 and ends 2023-01-17
        //The second date range starts 2023-01-10 and ends 2023-01-12
        yield return new object[]
        {
            new DateRange(new(2023, 01, 05), new(2023, 01, 17)),
            new DateRange(new(2023, 01, 10), new(2023, 01, 12))
        };

        //The first date range starts 2023-01-04 and ends 2023-01-10
        //The second date range starts 2023-01-07 and ends 2023-01-13
        yield return new object[]
        {
            new DateRange(new(2023, 01, 04), new(2023, 01, 10)),
            new DateRange(new(2023, 01, 07), new(2023, 01, 13))
        };

        //The first date range starts 2023-01-10 and ends 2023-01-16
        //The second date range starts 2023-01-07 and ends 2023-01-13
        yield return new object[]
        {
            new DateRange(new(2023, 01, 10), new(2023, 01, 16)),
            new DateRange(new(2023, 01, 07), new(2023, 01, 13))
        };
    }
}