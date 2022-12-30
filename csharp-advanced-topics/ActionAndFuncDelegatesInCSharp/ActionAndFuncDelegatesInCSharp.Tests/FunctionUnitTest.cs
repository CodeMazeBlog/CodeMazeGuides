namespace ActionAndFuncDelegatesInCSharp.Tests;

public class FunctionUnitTest
{
    [Fact]
    public void WhenDateTimeAndTimeZonePassed_ThenConvertedDateTimeReturns()
    {
        // Arrange
        string timeZoneName = "Central Standard Time";
        DateTime now = DateTime.Now;
        DateTime expected = TimeZoneInfo.ConvertTime(now, TimeZoneInfo.FindSystemTimeZoneById(timeZoneName));
        Func<DateTime, TimeZoneInfo, DateTime> timeConverter = Program.ConvertTimeByTimeZone;

        // Act
        DateTime result = timeConverter(now, TimeZoneInfo.FindSystemTimeZoneById(timeZoneName));

        // Assert
        Assert.Equal(expected, result);
    }
}