using Newtonsoft.Json.Linq;

namespace WorkdaysInCSharp;

public static class WorkdaysInCSharpMethods
{
    public static int CalculateBusinessDays(DateTime startDate, DateTime endDate)
    {
        var weekdays = 0;

        for (var currentDate = startDate; currentDate < endDate; currentDate = currentDate.AddDays(1))
        {
            if (IsWorkDay(currentDate))
            {
                weekdays++;
            }
        }

        return weekdays;
    }

    public static DateTime AddWorkDays(DateTime startDate, int workDays)
    {
        var endDate = startDate;

        while (workDays > 0)
        {
            endDate = endDate.AddDays(1);

            if (IsWorkDay(endDate))
            {
                workDays--;
            }
        }

        return endDate;
    }

    public static async Task<int> CalculateBusinessDaysExcludingHolidaysAsync(DateTime startDate, DateTime endDate,
                                                                              string countryCode)
    {
        var weekDays = 0;
        var holidaysArray = await GetHolidaysAsync(startDate.Year, countryCode);
        var holidays = new HashSet<string>(holidaysArray); 

        for (var currentDate = startDate.Date; currentDate < endDate.Date;)
        {
            if (IsWorkDay(currentDate))
            {
                var currentDateStr = currentDate.ToString("yyyy-MM-dd");

                if (!holidays.Contains(currentDateStr))
                {
                    weekDays++;
                }
            }

            currentDate = currentDate.AddDays(currentDate.DayOfWeek == DayOfWeek.Friday ? 3 : 1);
        }

        return weekDays;
    }

    public static async Task<DateTime> AddWorkDaysExcludingHolidaysAsync(DateTime startDate, int workDays,
                                                                         string countryCode)
    {
        var endDate = startDate;
        var holidays = await GetHolidaysAsync(startDate.Year, countryCode);

        while (workDays > 0)
        {
            endDate = endDate.AddDays(1);

            if (IsWorkDay(endDate) && !holidays.Contains(endDate.ToString("yyyy-MM-dd")))
            {
                workDays--;
            }
        }

        return endDate;
    }

    private static async Task<string[]> GetHolidaysAsync(int year, string countryCode)
    {
        HttpClient httpClient = new();
        var url = $"https://date.nager.at/api/v3/PublicHolidays/{year}/{countryCode}";
        var response = await httpClient.GetStringAsync(url);
        var holidays = JArray.Parse(response);
        var holidayDates = new string[holidays.Count];

        for (var i = 0; i < holidays.Count; i++)
        {
            holidayDates[i] = holidays[i]["date"].ToString();
        }

        return holidayDates;
    }

    public static bool IsWorkDay(DateTime date)
    {
        return date.DayOfWeek is not DayOfWeek.Saturday
            and not DayOfWeek.Sunday;
    }
}