using System.Globalization;

namespace GetFirstDayOfWeekDateInCSharp;

public static class FirstDayOfWeekMethods
{
    private static readonly Calendar _gregorianCalendar = new GregorianCalendar();

    public static DateTime FirstDateOfWeekISO8601(int year, int weekNumber)
    {
        var firstOfJan = new DateTime(year, 1, 1);
        var daysOffset = DayOfWeek.Thursday - firstOfJan.DayOfWeek;

        var firstThursdayOfYear = firstOfJan.AddDays(daysOffset);
        var firstWeekOfYear = _gregorianCalendar.GetWeekOfYear(firstThursdayOfYear,
            CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        if (firstWeekOfYear == 1)
        {
            weekNumber -= 1;
        }

        return firstThursdayOfYear.AddDays(weekNumber * 7 - 3);
    }
}