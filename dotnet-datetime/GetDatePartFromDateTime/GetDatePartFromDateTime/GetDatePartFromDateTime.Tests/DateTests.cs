using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GetDatePartFromDateTime.Tests
{
    [TestClass]
    public class DateTests
    {
        [TestMethod]
        public void RandomDate_GetDateProperty_DateComponentsAreEqual()
        {
            DateTime fullDate = new DateTime(2022, 02, 14, 10, 40, 00);

            DateTime datePart = fullDate.Date;

            Assert.IsTrue(datePart.Year == fullDate.Year && datePart.Month == fullDate.Month && datePart.Day == fullDate.Day);
        }

        [TestMethod]
        public void RandomDate_GetDateProperty_RemovesHourData()
        {
            DateTime fullDate = new DateTime(2022, 12, 14, 11, 23, 34);

            DateTime datePart = fullDate.Date;

            Assert.IsTrue(datePart.Hour != fullDate.Hour && datePart.Minute != fullDate.Minute && datePart.Second != fullDate.Second);
        }

        [TestMethod]
        public void RandomDate_GetDateProperty_SetsHourPartToDefault()
        {
            DateTime fullDate = new DateTime(2012, 10, 11, 11, 23, 34);

            DateTime datePart = fullDate.Date;

            Assert.IsTrue(datePart.Hour == 0 && datePart.Minute == 0 && datePart.Second == 0);
        }

        [TestMethod]
        public void DateOnly_OnGivenDateTime_CreatesCorrectDate() 
        {
            DateTime date = new DateTime(2021, 7, 8, 11, 10, 9);
            DateOnly dateOnly = new DateOnly(date.Year, date.Month, date.Day);

            Assert.IsTrue(dateOnly.Year == date.Year && dateOnly.Month == date.Month && dateOnly.Day == date.Day);
        }

        [TestMethod]
        public void DateFormat_OnGivenDateTime_CreatesCorrectDate()
        {
            DateTime date = new DateTime(2021, 7, 8, 11, 10, 9);

            Assert.IsTrue($"{date:MMM}" == "Jul" && $"{date:dd}" == "08" && $"{date:yy}" == "21");
        }
    }
}