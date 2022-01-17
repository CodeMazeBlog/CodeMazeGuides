using DateTimeOperators;
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

            var actual = Operators.AddOperation(dt, ts);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoDates_ThenRSubtractCorrectly() 
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var expected = new TimeSpan(365, 00, 0, 00);

            var actual = Operators.SubtractOperation(dt1, dt);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenDateandTimeSpan_ThenSubractCorrectly() 
        {
            var dt = new DateTime(2022, 1, 1);
            var ts = new TimeSpan(20, 4, 2, 1);
            var expected = new DateTime(2021, 12, 11, 19, 57, 59);

            var actual = Operators.SubtractOperation(dt, ts);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoEqualDates_ThenReturnTrue() 
        {
            var dt = new DateTime(2022, 1, 1);

            var actual = Operators.EqualityOperation(dt, dt);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnTrue()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            var actual = Operators.InequalityOperation(dt1, dt);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnGreaterThan()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var actual = Operators.GreaterThanOperation(dt1, dt);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnGreaterThanOrEqual()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var actual = Operators.GreaterThanOrEqualOperation(dt1, dt);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnLessThan()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            var actual = Operators.LessThanOperation(dt, dt1);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnLessThanOrEqual()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);

            var actual = Operators.LessThanOrEqualOperation(dt, dt1);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenDates_ThenCompareAccurately()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var expectedEqual = 0;
            var expectedMore = 1;
            var expectedLess = -1;   

            var actualEqual = Operators.CompareDates(dt, dt);
            var actualMore = Operators.CompareDates(dt1, dt);
            var actualLess = Operators.CompareDates(dt, dt1);

            Assert.AreEqual(expectedEqual, actualEqual);
            Assert.AreEqual(expectedLess, actualLess);
            Assert.AreEqual(expectedMore, actualMore);
        }
    }
}