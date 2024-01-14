namespace CheckNumberOfDaysBetweenTwoDates;
public class NumberOfDaysBetweenTwoDates
{
    public static int CalculateDaysUntilVacation(DateTime summerVacationStart, DateTime currentDate)
    {
        TimeSpan daysUntilVacation = summerVacationStart - currentDate;
        return daysUntilVacation.Days;
    }
}