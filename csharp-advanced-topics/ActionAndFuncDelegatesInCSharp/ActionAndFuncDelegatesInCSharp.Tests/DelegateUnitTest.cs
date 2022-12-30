namespace ActionAndFuncDelegatesInCSharp.Tests;

[Collection("Sequential")]
public class DelegateUnitTest
{
    [Fact]
    public void WhenDateTimeAndTimeZonePassed_ThenConvertedDateTimeReturns()
    {
        // Arrange
        string timeZoneName = "Central Standard Time";
        DateTime now = DateTime.Now;
        DateTime expected = TimeZoneInfo.ConvertTime(now, TimeZoneInfo.FindSystemTimeZoneById(timeZoneName));
        Program.TimeConverter timeConverter = Program.ConvertTimeByTimeZone;

        // Act
        DateTime result = timeConverter(now, TimeZoneInfo.FindSystemTimeZoneById(timeZoneName));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void WhenDateTimePassed_ThenDisplayLocaTimeZoneNameAndDateTime()
    {
        // Arrange
        DateTime now = DateTime.Now;
        string expected = $"Time in {TimeZoneInfo.Local.DisplayName} is {now}{Environment.NewLine}";
        Program.LocalTimeAndZoneName localTimeAndTimeZoneName = Program.DisplayLocalTimeAndTimeZone;
        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        // Act
        localTimeAndTimeZoneName(now);

        // Assert
        Assert.Equal(expected, stringWriter.ToString());
    }
}