using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CheckDateTime.Tests
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void GivenWorkday_CheckReturnsWorkday()
        {
            var date = new DateTime(2021, 12, 15);
            string result = string.Empty;
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                result = "Weekend";
            }
            else
            {
                result = "Workday";
            }

            Assert.AreEqual(result, "Workday");
        }

        [TestMethod]
        public void GivenWeekendDay_CheckReturnsWeekendDay()
        {
            var date = new DateTime(2021, 12, 4);
            string result = string.Empty;
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                result = "Weekend";
            }
            else
            {
                result = "Workday";
            }

            Assert.AreEqual(result, "Weekend");
        }

        [TestMethod]
        public void GivenWednesday_FormatShowsWednesday()
        {
            var date = new DateTime(2021, 10, 6);
            string customDateFormat = date.ToString("dddd, dd MMMM yyyy");

            Assert.IsTrue(customDateFormat.Contains("Wednesday"));
        }
    }
}
