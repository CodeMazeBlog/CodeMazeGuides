namespace Tests;

public class NumberOfDaysBetweenTwoDatesTests
{
    [Theory]
    [InlineData("2024-01-01", "2023-12-31", 1)] 
    [InlineData("2024-05-01", "2024-04-30", 1)] 
    [InlineData("2024-06-01", "2024-06-01", 0)] 
    [InlineData("2023-01-01", "2024-01-01", -365)] // Test with a past date
    [InlineData("2024-02-29", "2024-02-28", 1)] // Test with leap year date
    [InlineData("2074-01-01", "2024-01-01", 18263)] // Test with a distant future date
    public void GivenSpecificVacationStartDate_WhenCalculateDaysUntilVacationCalled_ThenReturnsCorrectNumberOfDays(string vacationDate, string currentDate, int expectedDays)
    {
        DateTime vacationStartDate = DateTime.Parse(vacationDate);
        DateTime currentTestDate = DateTime.Parse(currentDate);

        int actualDays = NumberOfDaysBetweenTwoDates.CalculateDaysUntilVacation(vacationStartDate, currentTestDate);

        Assert.Equal(expectedDays, actualDays);
    }
}

public class DifferentTimeZoneTests
{
    [Theory]
    [InlineData("2024-09-01T10:00:00-05:00", "2024-01-01T00:00:00-05:00", 244)]
    public void GivenSpecificDates_WhenCalculateDaysUntilEventCalled_ThenReturnsCorrectNumberOfDays(string eventDate, string currentDate, int expectedDays)
    {
        DateTimeOffset eventDateTime = DateTimeOffset.Parse(eventDate);
        DateTimeOffset currentDateTime = DateTimeOffset.Parse(currentDate);

        int actualDays = DifferentTimeZone.CalculateDaysUntilEvent(eventDateTime, currentDateTime);

        Assert.Equal(expectedDays, actualDays);
    }
}