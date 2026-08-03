namespace CheckNumberOfDaysBetweenTwoDates;

public static class NumberOfDaysBetweenTwoDates
{
    public static int CalculateDaysUntilVacation(DateTime summerVacationStart, DateTime currentDate)
    {
        TimeSpan daysUntilVacation = summerVacationStart - currentDate;

        return daysUntilVacation.Days;
    }

    public static int CalculateDaysUntilEvent(DateTimeOffset eventDateTime, DateTimeOffset currentDateTime)
    {
        TimeSpan daysUntilEvent = eventDateTime - currentDateTime;
        
        return daysUntilEvent.Days;
    }
}