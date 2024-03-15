namespace DateTimeOffsetVsDateTime.Tests;

public class DateTimeOffsetVsDateTimeTest
{
    [Fact]
    public void GivenUtcNow_WhenGettingKind_ThenShouldBeUtc()
    {
        Assert.Equal(DateTimeKind.Utc, DateTime.UtcNow.Kind);
    }

    [Fact]
    public void GivenNow_WhenGettingKind_ThenShouldBeLocal()
    {
        Assert.Equal(DateTimeKind.Local, DateTime.Now.Kind);
    }

    [Fact]
    public void GivenUnspecifiedKind_WhenGettingKind_ThenShouldBeUnspecified()
    {
        Assert.Equal(DateTimeKind.Unspecified, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified).Kind);
    }

    [Fact]
    public void GivenTimeZoneOffset_WhenGettingTimeZones_ThenShouldReturnCorrectTimeZones()
    {
        Assert.NotEmpty(TimeZoneInfo.GetSystemTimeZones().Where(item => item.BaseUtcOffset == new TimeSpan(2, 0, 0)));
    }
}
