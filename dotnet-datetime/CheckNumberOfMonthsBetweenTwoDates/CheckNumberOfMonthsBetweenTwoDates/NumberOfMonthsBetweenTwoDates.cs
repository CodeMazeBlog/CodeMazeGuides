namespace CheckNumberOfMonthsBetweenTwoDates;

public static class NumberOfMonthsBetweenTwoDates
{
    public static int CalculateSubscriptionDuration(DateOnly subscriptionStart, DateOnly endDate)
    {
        if (subscriptionStart > endDate)
        {
            throw new ArgumentOutOfRangeException(nameof(subscriptionStart), "The subscription start date must be before the end date.");
        }

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
        var courseStartUtc = courseStart.ToUniversalTime();
        var endDateUtc = endDate.ToUniversalTime();

        if (courseStartUtc > endDateUtc)
        {
            throw new ArgumentOutOfRangeException(nameof(courseStart), "The course start date must be before the end date.");
        }

        double totalDays = (endDateUtc - courseStartUtc).TotalDays;

        return totalDays / (365.2425 / 12);
    }
}