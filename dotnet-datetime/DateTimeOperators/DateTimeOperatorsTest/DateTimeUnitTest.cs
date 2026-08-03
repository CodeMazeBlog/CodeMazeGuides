using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DateTimeOperatorsTest
{
    [TestClass]
    public class DateTimeUnitTest
    {
        [TestMethod]
        public void GivenSameDateTimeAndTimeSpan_WhenTheyAreSame_ThenPlusAndAddReturnEqual()
        {
            var dt = new DateTime(2022, 1, 1);
            var ts = new TimeSpan(20, 4, 2, 1);
            var expected = new DateTime(2022, 1, 21, 4, 2, 1);

            Assert.AreEqual(expected, dt + ts);
            Assert.AreEqual(expected, dt.Add(ts));
            Assert.AreEqual(expected, dt.AddDays(20).AddHours(4).AddMinutes(2).AddSeconds(1));
        }

        [TestMethod]
        public void GivenTwoDifferentDates_WhenTheyAreNotSame_ThenSubtractAndReturnTiimeSpan() 
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var expected = new TimeSpan(365, 00, 0, 00);

            Assert.AreEqual(expected, dt1 - dt);
            Assert.AreEqual(expected, dt1.Subtract(dt));
        }

        [TestMethod]
        public void GivenDateAndTimeSpan_WhenTheyAreNotSame_ThenSubractAndReturnDateTime() 
        {
            var dt = new DateTime(2022, 1, 1);
            var ts = new TimeSpan(20, 4, 2, 1);
            var expected = new DateTime(2021, 12, 11, 19, 57, 59);

            Assert.AreEqual(expected, dt - ts);
            Assert.AreEqual(expected, dt.Subtract(ts));
            Assert.AreEqual(expected, dt.Add(-ts));
        }

        [TestMethod]
        public void GivenTwoEqualDates_WhenTheyAreSame_ThenReturnEqual() 
        {
            var dt = new DateTime(2022, 1, 1);

            Assert.IsTrue(dt == dt);
            Assert.IsTrue(dt.Equals(dt));
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_WhenTheyAreNotSame_ThenReturnNotEqual()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            Assert.IsTrue(dt != dt1);
            Assert.IsTrue(!dt.Equals(dt1));
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_WhenTheyAreNotSame_ThenCompareAndReturnGreaterThan()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
           
            Assert.IsTrue(dt1 > dt);
            Assert.AreEqual(1, DateTime.Compare(dt1, dt));
            Assert.AreEqual(1, dt1.CompareTo(dt));
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_WhenTheyAreNotSame_ThenReturnGreaterThanOrEqual()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            Assert.IsTrue(dt1 >= dt);
            Assert.AreEqual(0, DateTime.Compare(dt, dt));
            Assert.AreEqual(0, dt.CompareTo(dt));
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_WhenTheyAreNotSame_ThenReturnLessThan()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            Assert.IsTrue(dt < dt1);
            Assert.AreEqual(-1, DateTime.Compare(dt, dt1));
            Assert.AreEqual(-1, dt.CompareTo(dt1));
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_WhenTheyAreNotSameOrSame_ThenReturnLessThanOrEqual()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            Assert.IsTrue(dt <= dt1);
            Assert.AreEqual(0, DateTime.Compare(dt, dt));
            Assert.AreEqual(0, dt.CompareTo(dt));
        }
    }
}