namespace Tests;

public class NumberOfDaysBetweenTwoDatesTests
{
    [Theory]
    [InlineData("2024-01-01", 151)] // Test with New Year's Day
    [InlineData("2024-05-01", 31)]  // Test with May 1st
    [InlineData("2024-06-01", 0)]   // Test with the day of Summer Vacation
    [InlineData("2023-01-01", -365)] // Test with a past date
    [InlineData("2024-02-29", -1)]  // Test with leap year date
    [InlineData("2074-01-01", 18262)] // Test with a distant future date
    public void GivenSpecificVacationStartDate_WhenCalculateDaysUntilVacationCalled_ThenReturnsCorrectNumberOfDays(string vacationDate, int expectedDays)
    {
        DateTime vacationStartDate = DateTime.Parse(vacationDate);

        int actualDays = NumberOfDaysBetweenTwoDates.CalculateDaysUntilVacation(vacationStartDate);

        Assert.Equal(expectedDays, actualDays);
    }
}

public class DifferentTimeZoneTests
{
    [Theory]
    [InlineData("2024-09-01T10:00:00-05:00", "2024-01-01T00:00:00-05:00", 243)]
    public void GivenSpecificDates_WhenCalculateDaysUntilEventCalled_ThenReturnsCorrectNumberOfDays(string eventDate, string currentDate, int expectedDays)
    {
        DateTimeOffset eventDateTime = DateTimeOffset.Parse(eventDate);
        DateTimeOffset currentDateTime = DateTimeOffset.Parse(currentDate);

        int actualDays = DifferentTimeZone.CalculateDaysUntilEvent(eventDateTime, currentDateTime);

        Assert.Equal(expectedDays, actualDays);
    }
}