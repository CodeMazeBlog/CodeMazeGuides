using System.Globalization;

namespace CheckDateTime.Tests;

[TestClass]
public class DateTimeTests
{
    [TestMethod]
    public void GivenWorkday_WhenIsWeekend_ThenReturnsFalse()
    {
        var date = new DateTime(2021, 12, 15);

        Assert.IsFalse(date.IsWeekend());
    }

    [TestMethod]
    [DataRow(2021, 12, 4)]
    [DataRow(2021, 10, 10)]
    public void GivenSaturdayOrSunday_WhenIsWeekend_ThenReturnsTrue(int year, int month, int day)
    {
        var date = new DateTime(year, month, day);

        Assert.IsTrue(date.IsWeekend());
    }

    [TestMethod]
    public void GivenFridaySaturdayWeekend_WhenFriday_ThenReturnsTrue()
    {
        HashSet<DayOfWeek> fridaySaturday = [DayOfWeek.Friday, DayOfWeek.Saturday];

        Assert.IsTrue(new DateTime(2021, 10, 8).IsWeekend(fridaySaturday));
        Assert.IsFalse(new DateTime(2021, 10, 10).IsWeekend(fridaySaturday));
    }

    [TestMethod]
    public void GivenDayOfWeek_WhenCastToInt_ThenSundayIsZeroAndSaturdayIsSix()
    {
        Assert.AreEqual(0, (int)DayOfWeek.Sunday);
        Assert.AreEqual(6, (int)DayOfWeek.Saturday);
    }

    [TestMethod]
    public void GivenGermanCulture_WhenFormattingDayName_ThenOnlyFormatStringIsLocalized()
    {
        var sunday = new DateTime(2021, 10, 10);

        Assert.AreEqual("Sunday", sunday.DayOfWeek.ToString());
        Assert.AreEqual("Sonntag", sunday.ToString("dddd", new CultureInfo("de-DE")));
    }

    [TestMethod]
    public void GivenDateOnly_WhenReadingDayOfWeek_ThenMatchesDateTime()
    {
        Assert.AreEqual(DayOfWeek.Sunday, new DateOnly(2021, 10, 10).DayOfWeek);
    }

    [TestMethod]
    public void GivenWednesday_FormatShowsWednesday()
    {
        var date = new DateTime(2021, 10, 6);
        string customDateFormat = date.ToString("dddd, dd MMMM yyyy", CultureInfo.InvariantCulture);

        Assert.AreEqual("Wednesday, 06 October 2021", customDateFormat);
    }
}
