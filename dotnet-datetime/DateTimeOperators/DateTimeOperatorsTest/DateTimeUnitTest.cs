using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DateTimeOperatorsTest
{
    [TestClass]
    public class DateTimeUnitTest
    {
        [TestMethod]
        public void GivenTwoDates_ThenReturnCorrectSum()
        {
            var dt = new DateTime(2022, 1, 1);
            var ts = new TimeSpan(20, 4, 2, 1);
            var expected = new DateTime(2022, 1, 21, 4, 2, 1);

            Assert.AreEqual(expected, dt + ts);
            Assert.AreEqual(expected, dt.Add(ts));
            Assert.AreEqual(expected, dt.AddDays(20).AddHours(4).AddMinutes(2).AddSeconds(1));
        }

        [TestMethod]
        public void GivenTwoDates_ThenSubtractCorrectly() 
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var expected = new TimeSpan(365, 00, 0, 00);

            Assert.AreEqual(expected, dt1-dt);
            Assert.AreEqual(expected, dt1.Subtract(dt));
        }

        [TestMethod]
        public void GivenDateAndTimeSpan_ThenSubractCorrectly() 
        {
            var dt = new DateTime(2022, 1, 1);
            var ts = new TimeSpan(20, 4, 2, 1);
            var expected = new DateTime(2021, 12, 11, 19, 57, 59);

            Assert.AreEqual(expected, dt - ts);
            Assert.AreEqual(expected, dt.Subtract(ts));
            Assert.AreEqual(expected, dt.Add(-ts));
        }

        [TestMethod]
        public void GivenTwoEqualDates_ThenReturnTrue() 
        {
            var dt = new DateTime(2022, 1, 1);

            Assert.IsTrue(dt==dt);
            Assert.IsTrue(dt.Equals(dt));
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnTrue()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            Assert.IsTrue(dt!=dt1);
            Assert.IsTrue(!dt.Equals(dt1));
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnGreaterThan()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
           
            Assert.IsTrue(dt1 > dt);
            Assert.AreEqual(1, DateTime.Compare(dt1, dt));
            Assert.AreEqual(1, dt1.CompareTo(dt));
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnGreaterThanOrEqual()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            Assert.IsTrue(dt1 >= dt);
            Assert.AreEqual(0, DateTime.Compare(dt, dt));
            Assert.AreEqual(0, dt.CompareTo(dt));
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnLessThan()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            Assert.IsTrue(dt < dt1);
            Assert.AreEqual(-1, DateTime.Compare(dt, dt1));
            Assert.AreEqual(-1, dt.CompareTo(dt1));
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnLessThanOrEqual()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            Assert.IsTrue(dt <= dt1);
            Assert.AreEqual(0, DateTime.Compare(dt, dt));
            Assert.AreEqual(0, dt.CompareTo(dt));
        }
    }
}