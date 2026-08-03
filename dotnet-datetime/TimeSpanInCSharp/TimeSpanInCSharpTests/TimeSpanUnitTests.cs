namespace TimeSpanInCSharpTests
{
    [TestClass]
    public class TimeSpanUnitTests
    {
        [TestMethod]
        public void GivenTwoTimeSpanValues_WhenAddOperationExecuted_VerifyAccurateSum()
        {
            var firstTimeSpan = new TimeSpan(1, 60, 3600);
            var secondTimeSpan = new TimeSpan(2, 60, 3600);

            var actual = firstTimeSpan.Add(secondTimeSpan);
            var expected = firstTimeSpan + secondTimeSpan;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoTimeSpanValues_WhenCompareOperationExecuted_VerifyAccurateResult()
        {
            var firstTimeSpan = new TimeSpan(1, 60, 3600);
            var secondTimeSpan = new TimeSpan(1, 60, 3600);
            var thirdTimeSpan = new TimeSpan(3, 60, 4000);

            var equalTo = TimeSpan.Compare(firstTimeSpan, secondTimeSpan);
            var lessThan = TimeSpan.Compare(secondTimeSpan, thirdTimeSpan);
            var greaterThan = TimeSpan.Compare(thirdTimeSpan, firstTimeSpan);

            Assert.AreEqual(0, equalTo);
            Assert.AreEqual(-1, lessThan);
            Assert.AreEqual(1, greaterThan);
        }

        [TestMethod]
        public void GivenTwoTimeSpanValues_WhenCompareToOperationExecuted_VerifyAccurateResult()
        {
            var firstTimeSpan = new TimeSpan(1, 60, 3600);
            var secondTimeSpan = new TimeSpan(1, 60, 3600);
            var thirdTimeSpan = new TimeSpan(3, 60, 4000);

            var equalTo = firstTimeSpan.CompareTo(secondTimeSpan);
            var lessThan = secondTimeSpan.CompareTo(thirdTimeSpan);
            var greaterThan = thirdTimeSpan.CompareTo(firstTimeSpan);

            Assert.AreEqual(0, equalTo);
            Assert.AreEqual(-1, lessThan);
            Assert.AreEqual(1, greaterThan);
        }

        [TestMethod]
        public void GivenTwoTimeSpanValues_WhenDivideOperationExecuted_VerifyAccurateResult()
        {
            var firstTimeSpan = new TimeSpan(2, 60, 3600);
            var secondTimeSpan = new TimeSpan(1, 30, 1800);

            var expected = firstTimeSpan.Divide(secondTimeSpan);
            var actual = firstTimeSpan / secondTimeSpan;

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOfType(actual, typeof(double));
            Assert.IsInstanceOfType(expected, typeof(double));
        }

        [TestMethod]
        public void GivenATimeSpan_WhenDividedByDivisor_VerifyAccurateResult()
        {
            var firstTimeSpan = new TimeSpan(2, 60, 3600);
            var secondTimeSpan = new TimeSpan(1, 30, 1800);

            var divisionByMethod = firstTimeSpan.Divide(2);
            var divisionByOperator = firstTimeSpan / 2;

            Assert.AreEqual(divisionByMethod, secondTimeSpan);
            Assert.AreEqual(divisionByOperator, secondTimeSpan);
            Assert.IsInstanceOfType(divisionByMethod, typeof(TimeSpan));
            Assert.IsInstanceOfType(divisionByOperator, typeof(TimeSpan));
        }

        [TestMethod]
        public void GivenTwoTimeSpanValues_WhenEqualityOperationApplied_VerifyAccurateResult()
        {
            var firstTimeSpan = new TimeSpan(1, 60, 3600);
            var secondTimeSpan = new TimeSpan(1, 60, 3600);
            var thirdTimeSpan = new TimeSpan(3, 60, 4000);

            Assert.IsTrue(firstTimeSpan == secondTimeSpan);
            Assert.IsTrue(firstTimeSpan.Equals(secondTimeSpan));
            Assert.IsTrue(firstTimeSpan < thirdTimeSpan);
            Assert.IsTrue(thirdTimeSpan > secondTimeSpan);
            Assert.IsTrue(thirdTimeSpan >= secondTimeSpan);
            Assert.IsTrue(firstTimeSpan <= thirdTimeSpan);
            Assert.IsTrue(firstTimeSpan != thirdTimeSpan);
        }

        [TestMethod]
        public void GivenATimeSpanAndFactor_WhenMultiplied_VerifyAccurateResult()
        {
            var expected = new TimeSpan(2, 60, 3600);
            var firstTimeSpan = new TimeSpan(1, 30, 1800);
            var factor = 2;

            var multiplyMethod = firstTimeSpan.Multiply(factor);
            var multiplyOperator = firstTimeSpan * factor;

            Assert.AreEqual(multiplyMethod, multiplyOperator);
            Assert.AreEqual(expected, multiplyOperator);
            Assert.AreEqual(expected, multiplyMethod);
            Assert.IsInstanceOfType(multiplyMethod, typeof(TimeSpan));
            Assert.IsInstanceOfType(multiplyOperator, typeof(TimeSpan));
        }

        [TestMethod]
        public void GivenTwoTimeSpans_WhenSubtractOperationApplied_VerifyAccurateResult()
        {
            var firstTimeSpan = new TimeSpan(2, 60, 3600);
            var secondTimeSpan = new TimeSpan(1, 30, 1800);
            var expected = new TimeSpan(1, 30, 1800);

            var subtractMethod = firstTimeSpan.Subtract(secondTimeSpan);
            var subtractOperator = firstTimeSpan - secondTimeSpan;

            Assert.AreEqual(subtractMethod, subtractOperator);
            Assert.AreEqual(expected, subtractOperator);
            Assert.AreEqual(expected, subtractMethod);
            Assert.IsInstanceOfType(subtractMethod, typeof(TimeSpan));
            Assert.IsInstanceOfType(subtractOperator, typeof(TimeSpan));
        }

        [TestMethod]
        public void GivenATimeSpan_WhenConvertedToString_VerifyAccurateResult()
        {
            var firstTimeSpan = new TimeSpan(2, 60, 3600);
            var expected = "04:00:00";

            var actual = firstTimeSpan.ToString();
            
            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOfType(actual, typeof(string));
        }

        [TestMethod]
        public void GivenATimeSpan_WhenConvertedToDuration_VerifyAccurateResult()
        {
            var firstTimeSpan = new TimeSpan(2, 60, 3600);

            var actual = firstTimeSpan.Duration();
            var expected = new TimeSpan(04, 00, 00);

            Assert.AreEqual(actual, expected);
            Assert.IsInstanceOfType(actual, typeof(TimeSpan));
        }

        [TestMethod]
        public void GivenATimeSpan_WhenNegated_VerifyAccurateResult()
        {
            var firstTimeSpan = new TimeSpan(2, 60, 3600);
            var expected = new TimeSpan(-2, -60, -3600);

            var negateMethod = firstTimeSpan.Negate();
            var negateOperator = -(firstTimeSpan);

            Assert.AreEqual(negateMethod, expected);
            Assert.AreEqual(negateMethod, negateOperator);
            Assert.IsInstanceOfType(negateMethod, typeof(TimeSpan));
        }

        [TestMethod]
        public void GivenNumberOfDays_WhenFromDaysInvoked_VerifyAccurateResult()
        {
            var days = 2;
            var expected = new TimeSpan(46, 60, 3600);

            var actual = TimeSpan.FromDays(days);
            var totalDays = actual.TotalDays;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(days, totalDays);
        }

        [TestMethod]
        public void GivenNumberOfHours_WhenFromHoursInvoked_VerifyAccurateResult()
        {
            var hours = 4;
            var expected = new TimeSpan(2, 60, 3600);

            var actual = TimeSpan.FromHours(hours);
            var totalHours = actual.TotalHours;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(hours, totalHours);
        }
    }
}