using DateTimeOffsetVsDateTime;
namespace DateTimeOffsetVsDateTime.Tests;

public class DateTimeOffsetVsDateTimeTest
{    
    [Fact]
    public void DateTimeKind_ShouldBeUtc()
    {
        // Arrange
        DateTime dateTime = DateTime.UtcNow;

        // Act
        DateTimeKind kind = dateTime.Kind;

        // Assert
        Assert.Equal(DateTimeKind.Utc, kind);
    }
    [Fact]
    public void DateTimeKind_ShouldBeLocal()
    {
        // Arrange
        DateTime dateTime = DateTime.Now;

        // Act
        DateTimeKind kind = dateTime.Kind;

        // Assert
        Assert.Equal(DateTimeKind.Local, kind);
    }

    [Fact]
    public void DateTimeKind_ShouldBeUnspecified()
    {
        // Arrange
        DateTime dateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        // Act
        DateTimeKind kind = dateTime.Kind;

        // Assert
        Assert.Equal(DateTimeKind.Unspecified, kind);
    }

    [Fact]
    public void GetTimeZoneFromOffset_ShouldReturnCorrectTimeZones()
    {
        // Arrange
        TimeSpan offset = new TimeSpan(2, 0, 0); // For example, UTC+02:00  
        List<TimeZoneInfo> list = new List<TimeZoneInfo>();    
        TimeZoneInfo expectedTimeZone = TimeZoneInfo.FindSystemTimeZoneById("South Africa Standard Time"); // Replace with your expected time zone ID

        // Act
        foreach (TimeZoneInfo item in TimeZoneInfo.GetSystemTimeZones())
            {
                if(item.BaseUtcOffset == offset)
                {
                     list.Add(item);
                }
            }   

        // Assert
        Assert.Contains(expectedTimeZone, list);
    }
}

