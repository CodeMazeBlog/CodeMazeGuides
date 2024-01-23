namespace CheckNumberOfMonthsBetweenTwoDates;

public static class NumberOfMonthsBetweenTwoDates
{
    public static int CalculateSubscriptionDuration(DateTime subscriptionStart, DateTime currentDate)
    {
        int months = (currentDate.Year - subscriptionStart.Year) * 12 + currentDate.Month - subscriptionStart.Month;

        if (currentDate.Day < subscriptionStart.Day)
        {
            months--;
        }

        return months;
    }

    public static double CalculateCourseDuration(DateTime courseStart, DateTime currentDate)
    {
        double totalDays = (currentDate - courseStart).TotalDays;

        double totalMonths = totalDays / (365.25 / 12);

        return totalMonths;
    }
}