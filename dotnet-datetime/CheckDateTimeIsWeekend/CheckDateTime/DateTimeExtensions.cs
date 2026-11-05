namespace CheckDateTime;

public static class DateTimeExtensions
{
    public static bool IsWeekend(this DateTime date) =>
        date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

    public static bool IsWeekend(this DateTime date, IReadOnlySet<DayOfWeek> weekendDays) =>
        weekendDays.Contains(date.DayOfWeek);
}
