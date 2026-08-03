using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DateTimeNow.Tests
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void DifferentTimezones_WhenHoursCompared_ShouldReturnDifference()
        {
            var now = DateTime.Now;
            var utcNow = DateTime.UtcNow;

            var hoursDiff = TimeZoneInfo.Local.GetUtcOffset(now).TotalHours;
            
            if (hoursDiff == 0)
            {
                Assert.AreEqual(now.Hour, utcNow.Hour);
            }
            else 
            {
                Assert.AreNotEqual(now.Hour, utcNow.Hour);
            }
        }

        [TestMethod]
        public void LocalDate_WhenTestKind_ReturnsLocal() 
        {
            var now = DateTime.Now;
            Assert.AreEqual(now.Kind, DateTimeKind.Local);

        }

        [TestMethod]
        public void UTCDate_WhenTestKind_ReturnsUTC()
        {
            var utcNow = DateTime.UtcNow;
            Assert.AreEqual(utcNow.Kind, DateTimeKind.Utc);
        }

        [TestMethod]
        public void UTCDate_ConvertToLocal_ReturnsLocalDate()
        {
            var utcNow = DateTime.UtcNow;
            var local = utcNow.ToLocalTime();

            Assert.IsTrue(utcNow.Kind == DateTimeKind.Utc && local.Kind == DateTimeKind.Local);
        }

        [TestMethod]
        public void LocalDate_ConvertToUTC_ReturnsUTCDate()
        {
            var now = DateTime.Now;
            var utc = now.ToUniversalTime();

            Assert.IsTrue(now.Kind == DateTimeKind.Local && utc.Kind == DateTimeKind.Utc);
        }
    }
}