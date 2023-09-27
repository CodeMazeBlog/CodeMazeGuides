public class DateRange
{
    public DateOnly Start { get; private set; }
    public DateOnly End { get; private set; }

    public DateRange(DateOnly start, DateOnly end)
    {
        Start = start;
        End = end;
    }

    public bool Overlap(DateRange range)
    {
        return Start < range.End && End > range.Start;
    }
}