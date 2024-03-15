namespace CheckOverlapDates;

public static class OverlapChecker
{
    public static bool Overlap(DateOnly startDate1, DateOnly endDate1, DateOnly startDate2, DateOnly endDate2)
    {
        return startDate1 <= endDate2 && startDate2 <= endDate1;
    }

    public static bool OverlapTime(TimeOnly startTime1, TimeOnly endTime1, TimeOnly startTime2, TimeOnly endTime2)
    {
        return startTime1 <= endTime2 && startTime2 <= endTime1;
    }
}
