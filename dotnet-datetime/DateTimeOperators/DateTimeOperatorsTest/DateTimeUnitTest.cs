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
            var operators = new Operators();
            var expected = new DateTime(2022, 1, 21, 4, 2, 1);
            var actual = operators.AddOperation(dt, ts);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoDates_ThenRSubtractCorrectly() 
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var operators = new Operators();
            var expected = new TimeSpan(365, 00, 0, 00);
            var actual = operators.SubtractOperation(dt1, dt);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenDateandTimeSpan_ThenSubractCorrectly() 
        {
            var dt = new DateTime(2022, 1, 1);
            var ts = new TimeSpan(20, 4, 2, 1);
            var operators = new Operators();
            var expected = new DateTime(2021, 12, 11, 19, 57, 59);
            var actual = operators.SubtractOperation(dt, ts);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoEqualDates_ThenReturnTrue() 
        {
            var dt = new DateTime(2022, 1, 1);
            var operators = new Operators();
            var actual = operators.EqualityOperation(dt, dt);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnTrue()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var operators = new Operators();
            var actual = operators.InequalityOperation(dt1, dt);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnGreaterThan()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var operators = new Operators();
            var actual = operators.GreaterThanOperation(dt1, dt);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnGreaterThanOrEqual()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var operators = new Operators();
            var actual = operators.GreaterThanOrEqualOperation(dt1, dt);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnLessThan()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var operators = new Operators();
            var actual = operators.LessThanOperation(dt, dt1);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnLessThanOrEqual()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var operators = new Operators();
            var actual = operators.LessThanOrEqualOperation(dt, dt1);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenDates_ThenCompareAccurately()
        {
            var dt = new DateTime(2022, 1, 1);
            var dt1 = new DateTime(2023, 1, 1);
            var operators = new Operators();
            var expectedEqual = 0;
            var expectedMore = 1;
            var expectedLess = -1;   
            var actualEqual = operators.CompareDates(dt, dt);
            var actualMore = operators.CompareDates(dt1, dt);
            var actualLess = operators.CompareDates(dt, dt1);

            Assert.AreEqual(expectedEqual, actualEqual);
            Assert.AreEqual(expectedLess, actualLess);
            Assert.AreEqual(expectedMore, actualMore);
        }
    }
}