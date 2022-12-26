namespace ActionAndFuncDelegatesInCSharp.Tests;

[Collection("Sequential")]
public class ActionTests
{
    [Fact]
    public void WhenDateTimePassed_ThenDisplayLocaTimeZoneNameAndDateTime()
    {
        // Arrange
        DateTime now = DateTime.Now;
        string expected = $"Time in {TimeZoneInfo.Local.DisplayName} is {now}{Environment.NewLine}";
        Action<DateTime> localTimeAndTimeZoneName = Program.DisplayLocalTimeAndTimeZone;
        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        // Act
        localTimeAndTimeZoneName(now);

        // Assert
        Assert.Equal(expected, stringWriter.ToString());
    }
}