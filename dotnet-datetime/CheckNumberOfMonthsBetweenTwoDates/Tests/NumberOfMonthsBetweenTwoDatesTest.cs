namespace Tests;

public class NumberOfMonthsBetweenTwoDates
{
    [Theory]
    [InlineData("2023-04-10", "2024-01-09", 8)]
    [InlineData("2023-01-15", "2023-02-14", 0)]
    [InlineData("2023-05-01", "2023-05-31", 0)]
    [InlineData("2022-12-31", "2023-01-30", 0)]
    [InlineData("2021-01-01", "2023-01-01", 24)]
    public void GivenSpecificDates_WhenCalculateSubscriptionDurationCalled_ThenReturnsCorrectNumberOfMonths(string subscriptionStartDate, string currentDateString, int expectedMonths)
    {
        var subscriptionStart = DateTime.Parse(subscriptionStartDate);
        var currentDate = DateTime.Parse(currentDateString);

        int actualMonths = CheckNumberOfMonthsBetweenTwoDates.NumberOfMonthsBetweenTwoDates.CalculateSubscriptionDuration(subscriptionStart, currentDate);

        Assert.Equal(expectedMonths, actualMonths);
    }

    [Theory]
    [InlineData("2023-02-15", "2023-03-15", 0.92)]
    [InlineData("2023-09-12", "2024-01-12", 4)] 
    [InlineData("2023-01-01", "2023-12-31", 12)] 
    [InlineData("2022-06-15", "2023-06-14", 12)] 
    [InlineData("2021-01-01", "2023-01-01", 24)] 
    public void GivenSpecificDates_WhenCalculateCourseDurationCalled_ThenReturnsApproximateNumberOfMonths(string courseStartDate, string currentDateString, double expectedMonths)
    {
        var courseStart = DateTime.Parse(courseStartDate);
        var currentDate = DateTime.Parse(currentDateString);

        double actualMonths = CheckNumberOfMonthsBetweenTwoDates.NumberOfMonthsBetweenTwoDates.CalculateCourseDuration(courseStart, currentDate);

        double delta = 0.05; 
        Assert.True(Math.Abs(expectedMonths - actualMonths) <= delta);
    }
}