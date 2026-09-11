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

        [TestMethod]
        public void UnspecifiedDate_WhenConvertedToLocalTime_IsTreatedAsUtc()
        {
            var value = new DateTime(2022, 1, 9, 14, 34, 42);

            var unspecified = DateTime.SpecifyKind(value, DateTimeKind.Unspecified);
            var asUtc = DateTime.SpecifyKind(value, DateTimeKind.Utc);

            Assert.AreEqual(asUtc.ToLocalTime(), unspecified.ToLocalTime());
        }

        [TestMethod]
        public void UnspecifiedDate_WhenConvertedToUniversalTime_IsTreatedAsLocal()
        {
            var value = new DateTime(2022, 1, 9, 14, 34, 42);

            var unspecified = DateTime.SpecifyKind(value, DateTimeKind.Unspecified);
            var asLocal = DateTime.SpecifyKind(value, DateTimeKind.Local);

            Assert.AreEqual(asLocal.ToUniversalTime(), unspecified.ToUniversalTime());
        }
    }
}