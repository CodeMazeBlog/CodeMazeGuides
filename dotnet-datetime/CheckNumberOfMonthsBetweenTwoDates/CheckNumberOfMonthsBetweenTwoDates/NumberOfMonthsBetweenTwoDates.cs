namespace CheckNumberOfMonthsBetweenTwoDates;

public static class NumberOfMonthsBetweenTwoDates
{
    public static int CalculateSubscriptionDuration(DateTime subscriptionStart, DateTime endDate)
    {
        int months = (endDate.Year - subscriptionStart.Year) * 12 + endDate.Month - subscriptionStart.Month;

        if (endDate.Day < subscriptionStart.Day - 1)
        {
            months--;
        }

        if (subscriptionStart.Day == 1 && DateTime.DaysInMonth(endDate.Year, endDate.Month) == endDate.Day)
        {
            months++;
        }

        return months;
    }

    public static double CalculateCourseDuration(DateTime courseStart, DateTime endDate)
    {
        double totalDays = (endDate - courseStart).TotalDays + 1;

        double totalMonths = totalDays / (365.2425 / 12);

        return totalMonths;
    }
}