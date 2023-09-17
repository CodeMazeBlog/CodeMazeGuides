using NodaTime;
using NodaTime.Extensions;
using NodaTime.Text;

namespace HandlingDatesWithNodaTime.Extensions;

public static class NodaTimeExtensions
{
    public static Instant ConvertToInstant(this DateTime dateTime)
    {
        return dateTime.ToInstant();
    }

    public static Duration ConvertToDuration(this TimeSpan timeSpan)
    {
        return timeSpan.ToDuration();
    }

    public static LocalDate AddDays(this LocalDate date, int days)
    {
        return date.PlusDays(days);
    }

    public static Period CalculateDifference(this LocalDate startDate, DateTime endDate)
    {   
        var finalDate = LocalDate.FromDateTime(endDate);
        return Period.Between(startDate, finalDate, PeriodUnits.Years);
    }
}