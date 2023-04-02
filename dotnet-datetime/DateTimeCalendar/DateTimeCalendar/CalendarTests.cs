using System;
using System.Globalization;

namespace DateTimeCalendar
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
        public void WhenDateTimeHasCalendar_ThenGetsLocalizedMonthString()
        {
            var calendar = new HijriCalendar();
            var dateTime = new DateTime(1444, 4, 2, calendar);

            var defaultMonth = dateTime.ToString("MMMM");
            var culturalMonth = dateTime.ToString("MMMM", new CultureInfo("ar-SA"));

            Assert.Equal("October", defaultMonth);
            Assert.Equal("ربيع الآخر", culturalMonth);
        }

        [Fact]
        public void WhenUsingCultureInfo_ThenGetsCalendar()
        {
            var usCulture = new CultureInfo("en-US");
            var calendar = usCulture.Calendar;

            Assert.Equal(typeof(GregorianCalendar), calendar.GetType());
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

        [Fact]
        public void WhenUsingCultureInfo_CanChangeCalendar()
        {
            var saudiCulture = new CultureInfo("ar-SA");
            var optionalCalendars = saudiCulture.OptionalCalendars;

            if (Array.Exists(optionalCalendars, c => c.GetType() == typeof(GregorianCalendar)))
            {
                saudiCulture.DateTimeFormat.Calendar = new GregorianCalendar();
            }

            var saudiCalendar = saudiCulture.DateTimeFormat.Calendar.GetType();

            Assert.Equal(typeof(GregorianCalendar), saudiCalendar);
        }
    }
}