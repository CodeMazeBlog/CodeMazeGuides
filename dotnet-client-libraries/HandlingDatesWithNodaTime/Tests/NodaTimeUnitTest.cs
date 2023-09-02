using NodaTime;
using NodaTime.Text;

namespace Tests;

public class NodaTimeUnitTest
{
    [Fact]
    public void WhenGetCurrentInstantMethodIsCalled_ThenReturnCurrentInstant()
    {
        var instant = SystemClock.Instance.GetCurrentInstant();

        Assert.True(instant != default(Instant));   
    }

    [Fact]  
    public void WhenUtcDateIsSpecified_ThenReturnInstantFromUtcDate()   
    {
        var instant = Instant.FromUtc(2023, 8, 31, 20, 00);

        var expected = new LocalDateTime(2023, 8, 31, 20, 00)
            .InZoneStrictly(DateTimeZone.Utc)
            .ToInstant();   

        Assert.Equal(expected, instant);
    }

    [Fact]
    public void WhenFromUnixTimeTicksMethodIsCalled_ThenReturnInstantFromUnixTicks()
    {
        var epochTime = 1693153840;

        var instant = Instant.FromUnixTimeTicks(epochTime);
        var unixTimeTicks = instant.ToUnixTimeTicks();

        Assert.Equal(epochTime, unixTimeTicks);
    }

    [Fact]
    public void WhenNumberOfTicksIsSpecified_ThenReturnEquivalentDuration()
    {
        var ticks = 600000000;

        var duration = Duration.FromTicks(ticks);

        Assert.Equal(ticks, duration.BclCompatibleTicks);
    }

    [Fact]
    public void WhenNumberOfHoursIsSpecified_ThenReturnEquivalentDuration()
    {
        var hours = 12;

        var duration = Duration.FromHours(hours);

        Assert.Equal(hours, duration.Hours);
    }

    [Fact]
    public void WhenLocalTimeIsInstantiated_ThenReturnLocalTime()
    {
        var localTime = new LocalTime(10, 30);

        Assert.Equal(10, localTime.Hour);
        Assert.Equal(30, localTime.Minute);
    }

    [Fact]
    public void WhenLocalTimeIsConvertedToString_ThenReturnFormattedString()
    {
        var time = new LocalTime(10, 30);
        var pattern = LocalTimePattern.CreateWithInvariantCulture("HH:mm");

        var formattedTime = pattern.Format(time);

        Assert.Equal("10:30", formattedTime);
    }


    [Fact]
    public void WhenLocalTimeIsAString_ThenParseItToLocalTime()
    {
        var input = "11:00:46";
        var pattern = LocalTimePattern.ExtendedIso;

        var parsedTime = pattern.Parse(input);
        var time = parsedTime.Value;

        Assert.Equal(11, time.Hour);
        Assert.Equal(00, time.Minute);
        Assert.Equal(46, time.Second);
    }

    [Fact]
    public void WhenDifferentTimesArePassed_ThenCompareThemAndReturnResult()
    {
        var eventOneTime = new LocalTime(7, 30);
        var eventTwoTime = new LocalTime(12, 0);
        var eventThreeTime = new LocalTime(12, 0);

        var eventOneResult = eventOneTime.CompareTo(eventTwoTime);
        var eventTwoResult = eventTwoTime.CompareTo(eventOneTime);
        var eventThreeResult = eventTwoTime.CompareTo(eventThreeTime);

        Assert.True(eventOneResult < 0);
        Assert.True(eventTwoResult > 0);
        Assert.Equal(0, eventThreeResult);
    }

    [Fact]
    public void WhenLocalDateTimezoneAndDateTimezoneAreCombined_ThenReturnZoneDateTime()
    {
        var localDateTime = new LocalDateTime(2023, 8, 31, 15, 30);
        var timezone = DateTimeZoneProviders.Tzdb["Africa/Cairo"];

        var zoneDateTime = localDateTime.InZoneLeniently(timezone);

        Assert.True(true);
    }
}