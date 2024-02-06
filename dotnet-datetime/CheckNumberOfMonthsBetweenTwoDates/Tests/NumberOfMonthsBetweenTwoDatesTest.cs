namespace Tests;

public class NumberOfMonthsBetweenTwoDates
{
    [Theory]
    [InlineData("2023-04-10", "2024-01-09", 9)]
    [InlineData("2023-01-15", "2023-02-14", 1)]
    [InlineData("2023-05-01", "2023-05-31", 1)]
    [InlineData("2022-12-31", "2023-01-30", 1)]
    [InlineData("2021-01-01", "2023-01-01", 24)]
    [InlineData("2014-02-28", "2024-02-27", 120)]
    [InlineData("2023-01-01", "2023-01-01", 0)]
    [InlineData("2023-01-29", "2023-02-28", 1)]
    [InlineData("2024-02-28", "2024-03-29", 1)]
    [InlineData("2023-02-28", "2024-02-29", 12)]
    [InlineData("2023-01-01", "2023-02-28", 2)]
    public void GivenSpecificDates_WhenCalculateSubscriptionDurationCalled_ThenReturnsCorrectNumberOfMonths(string subscriptionStartDate, string endDateString, int expectedMonths)
    {
        var subscriptionStart = DateTime.Parse(subscriptionStartDate);
        var endDate = DateTime.Parse(endDateString);

        int actualMonths = CheckNumberOfMonthsBetweenTwoDates.NumberOfMonthsBetweenTwoDates.CalculateSubscriptionDuration(subscriptionStart, endDate);

        Assert.Equal(expectedMonths, actualMonths);
    }

    [Theory]
    [InlineData("2023-02-15", "2023-03-15", 0.92)]
    [InlineData("2023-09-12", "2024-01-12", 4.01)]
    [InlineData("2023-01-01", "2023-12-31", 11.96)]
    [InlineData("2022-06-15", "2023-06-14", 11.96)]
    [InlineData("2021-01-01", "2023-01-01", 23.98)]
    public void GivenSpecificDates_WhenCalculateCourseDurationCalled_ThenReturnsApproximateNumberOfMonths(string courseStartDate, string endDateString, double expectedMonths)
    {
        var courseStart = DateTime.Parse(courseStartDate);
        var endDate = DateTime.Parse(endDateString);

        double actualMonths = CheckNumberOfMonthsBetweenTwoDates.NumberOfMonthsBetweenTwoDates.CalculateCourseDuration(courseStart, endDate);

        double delta = 0.05;
        Assert.True(Math.Abs(expectedMonths - actualMonths) <= delta);
    }
}