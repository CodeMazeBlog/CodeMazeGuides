namespace CheckNumberOfDaysBetweenTwoDates;
public class DifferentTimeZone
{
    public static int CalculateDaysUntilEvent(DateTimeOffset eventDateTime, DateTimeOffset currentDateTime)
    {
        TimeSpan daysUntilEvent = eventDateTime - currentDateTime;
        return daysUntilEvent.Days;
    }
}