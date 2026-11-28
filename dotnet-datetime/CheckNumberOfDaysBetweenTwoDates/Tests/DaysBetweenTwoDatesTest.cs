namespace Tests;

public class NumberOfDaysBetweenTwoDatesTests
{
    [Theory]
    [InlineData("2024-01-01T14:00", "2023-12-31T10:00", 1)]
    [InlineData("2024-05-01T09:30", "2024-04-30T20:45", 0)]
    [InlineData("2024-06-01T00:00", "2024-06-01T00:00", 0)]
    [InlineData("2023-01-01T15:30", "2024-01-01T08:15", -364)]
    [InlineData("2024-02-29T12:00", "2024-02-28T18:00", 0)]
    [InlineData("2074-01-01T10:00", "2024-01-01T05:00", 18263)]
    [InlineData("2024-06-01T00:00", "2024-01-13T00:00", 140)]
    [InlineData("2024-06-01T00:00", "2024-01-13T18:00", 139)]
    public void GivenSpecificVacationStartDate_WhenCalculateDaysUntilVacationCalled_ThenReturnsCorrectNumberOfDays(string vacationDate, string currentDate, int expectedDays)
    {
        var vacationStartDate = DateTime.Parse(vacationDate, CultureInfo.InvariantCulture);
        var currentTestDate = DateTime.Parse(currentDate, CultureInfo.InvariantCulture);

        int actualDays = NumberOfDaysBetweenTwoDates.CalculateDaysUntilVacation(vacationStartDate, currentTestDate);

        Assert.Equal(expectedDays, actualDays);
    }

    [Theory]
    [InlineData("2024-09-01T10:00:00-04:00", "2024-01-01T00:00:00-05:00", 244)]
    [InlineData("2024-09-01T10:00:00-04:00", "2024-01-13T18:00:00+01:00", 231)]
    [InlineData("2024-12-31T23:59:59-05:00", "2024-01-01T00:00:00-05:00", 365)]
    [InlineData("2024-07-04T12:00:00-04:00", "2024-07-03T12:00:00-04:00", 1)]
    [InlineData("2024-11-28T08:00:00+00:00", "2024-11-27T20:00:00-08:00", 0)]
    [InlineData("2024-03-10T12:00:00-04:00", "2024-03-09T12:00:00-05:00", 0)]
    public void GivenSpecificDates_WhenCalculateDaysUntilEventCalled_ThenReturnsCorrectNumberOfDays(string eventDate, string currentDate, int expectedDays)
    {
        var eventDateTime = DateTimeOffset.Parse(eventDate, CultureInfo.InvariantCulture);
        var currentDateTime = DateTimeOffset.Parse(currentDate, CultureInfo.InvariantCulture);

        int actualDays = NumberOfDaysBetweenTwoDates.CalculateDaysUntilEvent(eventDateTime, currentDateTime);

        Assert.Equal(expectedDays, actualDays);
    }

    [Theory]
    [InlineData("2024-01-13", "2024-06-01", 140)]
    [InlineData("2024-02-28", "2024-03-01", 2)]
    [InlineData("2023-02-28", "2023-03-01", 1)]
    [InlineData("2024-06-01", "2024-01-13", -140)]
    [InlineData("2024-06-01", "2024-06-01", 0)]
    public void GivenTwoDateOnlyValues_WhenCalculateDaysBetweenDatesCalled_ThenReturnsCorrectNumberOfDays(string startDate, string endDate, int expectedDays)
    {
        var start = DateOnly.Parse(startDate, CultureInfo.InvariantCulture);
        var end = DateOnly.Parse(endDate, CultureInfo.InvariantCulture);

        int actualDays = NumberOfDaysBetweenTwoDates.CalculateDaysBetweenDates(start, end);

        Assert.Equal(expectedDays, actualDays);
    }
}
