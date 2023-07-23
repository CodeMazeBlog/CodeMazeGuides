using System.Globalization;

namespace Tests
{
    public class CalendarTests
    {
        [Fact]
        public void WhenUsingCalendar_ThenGetsDaysInMonth()
        {
            var calendar = new GregorianCalendar();
            var daysInJanuary = calendar.GetDaysInMonth(2023, 1);

            Assert.Equal(31, daysInJanuary);
        }

        [Fact]
        public void WhenDateTimeHasCalendar_ThenTheInternalRepresentationIsInGregorianCalendar()
        {
            var calendar = new HijriCalendar();
            var dateTime = new DateTime(1444, 4, 2, calendar);

            Assert.Equal(2022, dateTime.Year);
            Assert.Equal(10, dateTime.Month);
            Assert.Equal(27, dateTime.Day);
        }

        [Fact]
        public void WhenUsingCultureInfo_ThenGetOptionalCalendars()
        {
            var cultureInfo = new CultureInfo("ar-SA");
            var optionalCalendars = cultureInfo.OptionalCalendars;

            Assert.Equal(3, optionalCalendars.Length);
            Assert.Equal("UmAlQuraCalendar", optionalCalendars[0].GetType().Name);
            Assert.Equal("GregorianCalendar", optionalCalendars[1].GetType().Name);
            Assert.Equal("HijriCalendar", optionalCalendars[2].GetType().Name);
        }

        [Fact]
        public void WhenUsingCultureInfo_ThenPrintCorrectFormat()
        {
            CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
            var date = new DateTime(2023, 06, 18, 14, 00, 00);

            var formattedDate = date.ToString("f");

            Assert.Equal("dimanche 18 juin 2023 14:00", formattedDate);
        }

        [Fact]
        public void WhenUsingSaudiCultureInfoWithFrenchFormatProvider_ThenPrintFrenchFormat()
        {
            CultureInfo.CurrentCulture = new CultureInfo("ar-SA");
            var date = new DateTime(2023, 06, 18, 14, 00, 00);

            var formattedDate = date.ToString("f", new CultureInfo("fr-FR"));

            Assert.Equal("dimanche 18 juin 2023 14:00", formattedDate);
        }

        [Fact]
        public void WhenUsingCultureInfo_ThenGetsCalendar()
        {
            var usCulture = new CultureInfo("en-US");
            var usCalendar = usCulture.Calendar;

            var daysInMonth = usCalendar.GetDaysInMonth(2023, 3);

            Assert.Equal(31, daysInMonth);
        }

        [Fact]
        public void WhenUsingCultureInfo_CanCompareDates()
        {
            var usCulture = new CultureInfo("en-US");
            var saudiCulture = new CultureInfo("ar-SA");

            var usDate = new DateTime(2023, 3, 21, usCulture.Calendar);
            var saudiDate = new DateTime(1444, 8, 10, saudiCulture.Calendar);

            Assert.True(usDate > saudiDate);
        }
    }
}