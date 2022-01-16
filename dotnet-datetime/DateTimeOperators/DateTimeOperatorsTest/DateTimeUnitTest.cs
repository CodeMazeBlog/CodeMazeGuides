using DateTimeOperators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DateTimeOperatorsTest
{
    [TestClass]
    public class DateTimeUnitTest
    {
        //declaration of variables
        DateTime dt = new DateTime(2022, 1, 1);
        DateTime dt1 = new DateTime(2023, 1, 1);
        TimeSpan ts = new TimeSpan(20, 4, 2, 1);
        Operators operators = new Operators();

        [TestMethod]
        public void GivenTwoDates_ThenReturnCorrectSum()
        {
            DateTime expected = new DateTime(2022, 1, 21, 4, 2, 1);
            DateTime actual = operators.AddOperation(dt, ts);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoDates_ThenRSubtractCorrectly() 
        {
            TimeSpan expected = new TimeSpan(365, 00, 0, 00);
            TimeSpan actual = operators.SubtractOperation(dt1, dt);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenDateandTimeSpan_ThenSubractCorrectly() 
        {
            DateTime expected = new DateTime(2021, 12, 11, 19, 57, 59);
            DateTime actual = operators.SubtractOperation(dt, ts);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoEqualDates_ThenReturnTrue() 
        {
            bool expected = true;
            bool actual = operators.EqualityOperation(dt, dt);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnTrue()
        {
            bool expected = true;
            bool actual = operators.InequalityOperation(dt1, dt);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnGreaterThan()
        {
            bool expected = true;
            bool actual = operators.GreaterThanOperation(dt1, dt);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoNotEqualDates_ThenReturnLessThan()
        {
            bool expected = true;
            bool actual = operators.LessThanOperation(dt, dt1);

            Assert.AreEqual(expected, actual);
        }
    }
}