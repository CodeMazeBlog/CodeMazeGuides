public class DateRange
{
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }

    public DateRange(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public bool Overlap(DateRange range)
    {
        return Start < range.End && End > range.Start;
    }
}