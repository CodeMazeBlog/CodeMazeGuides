namespace CheckNumberOfDaysBetweenTwoDates;
public class NumberOfDaysBetweenTwoDates
{
    public static int CalculateDaysUntilVacation(DateTime summerVacationStart)
    {
        DateTime today = DateTime.Today;

        TimeSpan daysUntilVacation = summerVacationStart - today;
        return daysUntilVacation.Days;
    }
}