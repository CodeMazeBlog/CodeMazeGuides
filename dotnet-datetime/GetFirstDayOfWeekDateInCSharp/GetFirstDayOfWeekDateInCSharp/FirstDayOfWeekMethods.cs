using System.Globalization;

namespace GetFirstDayOfWeekDateInCSharp;

public class FirstDayOfWeekMethods
{
    public static DateTime FirstDateOfWeekISO8601(int year, int week)
    {
        var firstOfJan = new DateTime(year, 1, 1);
        int daysOffset = DayOfWeek.Thursday - firstOfJan.DayOfWeek;

        var firstThursdayOfYear = firstOfJan.AddDays(daysOffset);
        var calendar = CultureInfo.CurrentCulture.Calendar;
        var firstWeekOfYear = calendar.GetWeekOfYear(firstThursdayOfYear, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        var weekNumber = week;
       
        if (firstWeekOfYear == 1)
        {
            weekNumber -= 1;
        }

        var dateResult = firstThursdayOfYear.AddDays(weekNumber * 7);

        return dateResult.AddDays(-3);
    }
}