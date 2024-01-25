namespace CheckNumberOfMonthsBetweenTwoDates;

public static class NumberOfMonthsBetweenTwoDates
{
    public static int CalculateSubscriptionDuration(DateTime subscriptionStart, DateTime endDate)
    {
        int months = (endDate.Year - subscriptionStart.Year) * 12 + endDate.Month - subscriptionStart.Month;

        if (endDate.Day < subscriptionStart.Day)
        {
            months--;
        }

        return months;
    }

    public static double CalculateCourseDuration(DateTime courseStart, DateTime endDate)
    {
        double totalDays = (endDate - courseStart).TotalDays;

        double totalMonths = totalDays / (365.2425 / 12);

        return totalMonths;
    }
}