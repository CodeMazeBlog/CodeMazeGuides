using NodaTime;
using NodaTime.Extensions;
using NodaTime.Text;

namespace Tests;

public class NodaTimeUnitTest
{
    [Fact]
    public void WhenGetCurrentInstantMethodIsCalled_ThenReturnCurrentInstant()
    {
        var instant = SystemClock.Instance.GetCurrentInstant();

        Assert.True(instant != default);
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

        Assert.Equal(-1, eventOneResult);
        Assert.Equal(1, eventTwoResult);
        Assert.Equal(0, eventThreeResult);
    }

    [Fact]
    public void WhenLocalDateTimezoneAndDateTimezoneAreCombined_ThenReturnZoneDateTime()
    {
        var localDateTime = new LocalDateTime(2023, 8, 31, 15, 30);
        var timezone = DateTimeZoneProviders.Tzdb["Africa/Cairo"];

        var zoneDateTime = localDateTime.InZoneLeniently(timezone);

        Assert.Equal("Africa/Cairo", zoneDateTime.Zone.Id);
    }

    [Fact]
    public void WhenDurationsAreAdded_ThenReturnSumOfDuration()
    {
        var durationInDays = Duration.FromDays(1);
        var durationInHours = Duration.FromHours(3);

        var sumOfDurations = durationInDays + durationInHours;

        Assert.Equal( 1.125, sumOfDurations.TotalDays);
    }

    [Fact]
    public void WhenDurationsAreSubtracted_ThenReturnDifferenceOfDuration()
    {
        var firstDuration = Duration.FromHours(3);
        var secondDuration = Duration.FromHours(2);

        var difference = firstDuration - secondDuration;

        Assert.Equal(Duration.FromHours(1), difference);
    }

    [Fact]
    public void WhenDateTimeIsConvertedToInstant_ThenReturnInstant()
    {
        var dateTime = new DateTime(2023, 9, 15, 9, 30, 50, DateTimeKind.Utc);
        var expectedInstant = Instant.FromUtc(2023, 9, 15, 9, 30, 50);

        var instant = dateTime.ToInstant();

        Assert.Equal(expectedInstant, instant);
    }

    [Fact]
    public void WhenTimeSpanIsConvertedToDuration_TheReturnDuration()
    {
        var timeSpan = TimeSpan.FromHours(3);
        var expectedDuration = Duration.FromHours(3);

        var duration = timeSpan.ToDuration();

        Assert.Equal(expectedDuration, duration);
    }

    [Fact]
    public void WhenDaysAreAddedToLocalDate_ThenReturnLocalDate()
    {
        var currentDate = new LocalDate(2023, 9, 15);
        var expectedDate = new LocalDate(2023, 9, 16);

        var futureDate = currentDate.PlusDays(1);

        Assert.Equal(expectedDate, futureDate);
    }

    [Fact]
    public void WhenTwoDatesArePassed_ThenCalculateTheDifference()
    {
        var startDate = new LocalDate(1985, 12, 12);

        var endDate = new DateTime(2023, 9, 15, 9, 30, 50);

        var finalDate = LocalDate.FromDateTime(endDate);
        var difference = Period.Between(startDate, finalDate, PeriodUnits.Years);

        Assert.Equal(37, difference.Years);
    }

    [Fact]
    public void WhenLocalDateTimePatternIsDefined_ThenParseDateTimeValue()
    {
        var dateTimeText = "2023-09-17 14:30:00";
        var localDateTimePattern = LocalDateTimePattern.CreateWithInvariantCulture("yyyy-MM-dd HH:mm:ss");

        var parsedDateTime = localDateTimePattern.Parse(dateTimeText).Value;

        Assert.Equal(2023, parsedDateTime.Year);
        Assert.Equal(09, parsedDateTime.Month);
        Assert.Equal(17, parsedDateTime.Day);
        Assert.Equal(14, parsedDateTime.Hour);
        Assert.Equal(30, parsedDateTime.Minute);
        Assert.Equal(00, parsedDateTime.Second);
    }

    [Fact]
    public void WhenLocalDatePatternIsSpecified_ThenFormatNodaTimeType()
    {
        var dateToFormat = new LocalDate(2023, 9, 17);
        var localDatePattern = LocalDatePattern.CreateWithInvariantCulture("yyyy-MM-dd");

        var formattedDate = localDatePattern.Format(dateToFormat);

        Assert.Equal("2023-09-17", formattedDate);
    }

    [Fact]
    public void WhenTimeZoneIsSpecified_ThenReturnDateTimeZone()
    {
        var timeZoneId = "America/New_York";

        var newYorkTimeZone = DateTimeZoneProviders.Tzdb[timeZoneId];

        Assert.NotNull(newYorkTimeZone);
        Assert.Equal(timeZoneId, newYorkTimeZone.Id);
    }
}

