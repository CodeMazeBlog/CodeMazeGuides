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
    [MemberData(nameof(DontOverlapTimeOnly))]
    public void GivenTwoTimeRanges_WhenUsingOverlapCheckerClass_ThenReturnFalseIfTheyOverlap(TimeOnly firstTimeOnly, TimeOnly secondTime, TimeOnly thirdTimeOnly, TimeOnly fourthTime)
    {
        var result = OverlapChecker.OverlapTime(firstTimeOnly, secondTime, thirdTimeOnly, fourthTime);

        Assert.False(result);
    }

    [Theory]
    [MemberData(nameof(OverlapTimeOnly))]
    public void GivenTwoTimeRanges_WhenUsingOverlapCheckerClass_ThenReturnTrueIfTheyOverlap(TimeOnly firstTimeOnly, TimeOnly secondTime, TimeOnly thirdTimeOnly, TimeOnly fourthTime)
    {
        var result = OverlapChecker.OverlapTime(firstTimeOnly, secondTime, thirdTimeOnly, fourthTime);

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

    public static IEnumerable<object[]> DontOverlapTimeOnly()
    {
        //The first Time starts at 12:00 and ends at 13:00
        //The second Time starts at 14:00 and ends at 15:00.
        yield return new object[]
        {
            new TimeOnly(12, 00),
            new TimeOnly(13, 00),
            new TimeOnly(14, 00),
            new TimeOnly(15, 00)
        };

        //The first Time starts at 12:00 and ends at 13:00
        //The second Time starts at 08:00 and ends at 09:00.
        yield return new object[]
        {
            new TimeOnly(12,00),
            new TimeOnly(13,00),
            new TimeOnly(08,00),
            new TimeOnly(09,00)
        };
    }
    public static IEnumerable<object[]> OverlapTimeOnly()
    {
        //The first Time starts at 12:00 and ends at 14:00
        //The second Time starts at 10:00 and ends at 16:00
        yield return new object[]
        {
            new TimeOnly(12, 00),
            new TimeOnly(14, 00),
            new TimeOnly(10, 00),
            new TimeOnly(16, 00)
        };

        //The first Time starts at 12:00 and ends at 16:00
        //The second Time starts at 13:00 and ends at 14:00
        yield return new object[]
        {
            new TimeOnly(12, 00),
            new TimeOnly(16, 00),
            new TimeOnly(13, 00),
            new TimeOnly(14, 00)
        };

        //The first Time starts at 12:00 and ends at 14:00
        //The second Time starts at 13:00 and ends at 16:00
        yield return new object[]
        {
            new TimeOnly(12, 00),
            new TimeOnly(14, 00),
            new TimeOnly(13, 00),
            new TimeOnly(16, 00)
        };

        //The first Time starts at 12:00 and ends at 16:00
        //The second Time starts at 11:00 and ends at 15:00
        yield return new object[]
        {
            new TimeOnly(12, 00),
            new TimeOnly(16, 00),
            new TimeOnly(11, 00),
            new TimeOnly(15, 00)
        };
    }
}