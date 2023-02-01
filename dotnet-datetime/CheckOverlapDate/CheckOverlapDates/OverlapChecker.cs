namespace CheckOverlapDates;

public static class OverlapChecker
{
    public static bool Overlap(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2)
    {
        return startDate1 < endDate2 && startDate2 < endDate1;
    }
}
