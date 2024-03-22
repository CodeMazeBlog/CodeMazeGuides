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
        var subscriptionStart = DateOnly.Parse(subscriptionStartDate);
        var endDate = DateOnly.Parse(endDateString);

        int actualMonths = CheckNumberOfMonthsBetweenTwoDates.NumberOfMonthsBetweenTwoDates.CalculateSubscriptionDuration(subscriptionStart, endDate);

        Assert.Equal(expectedMonths, actualMonths);
    }

    [Theory]
    [InlineData("2024-01-09", "2023-04-10")]
    [InlineData("2023-03-15", "2023-02-15")]
    [InlineData("2030-01-01", "2023-01-01")]
    [InlineData("2025-12-31", "2020-01-01")]
    [InlineData("2040-06-15", "2030-12-31")]
    [InlineData("2028-07-01", "2023-06-30")]
    [InlineData("2035-02-28", "2025-02-27")]
    public void GivenStartDateAfterEndDate_WhenCalculateSubscriptionDurationCalled_ThenThrowsArgumentOutOfRangeException(string subscriptionStartDate, string endDateString)
    {
        var subscriptionStart = DateOnly.Parse(subscriptionStartDate);
        var endDate = DateOnly.Parse(endDateString);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CheckNumberOfMonthsBetweenTwoDates.NumberOfMonthsBetweenTwoDates.CalculateSubscriptionDuration(subscriptionStart, endDate));

        Assert.Equal("subscriptionStart", exception.ParamName);
        Assert.Contains("The subscription start date must be before the end date.", exception.Message);
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

    [Theory]
    [InlineData("2024-01-09", "2023-04-10")]
    [InlineData("2023-03-15", "2023-02-15")]
    [InlineData("2030-01-01", "2023-01-01")]
    [InlineData("2025-12-31", "2020-01-01")]
    [InlineData("2040-06-15", "2030-12-31")]
    [InlineData("2028-07-01", "2023-06-30")]
    [InlineData("2035-02-28", "2025-02-27")]
    public void GivenStartDateAfterEndDate_WhenCalculateCourseDurationCalled_ThenThrowsArgumentOutOfRangeException(string courseStartDate, string endDateString)
    {
        var courseStart = DateTime.Parse(courseStartDate);
        var endDate = DateTime.Parse(endDateString);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CheckNumberOfMonthsBetweenTwoDates.NumberOfMonthsBetweenTwoDates.CalculateCourseDuration(courseStart, endDate));

        Assert.Equal("courseStart", exception.ParamName);
        Assert.Contains("The course start date must be before the end date.", exception.Message);
    }
}