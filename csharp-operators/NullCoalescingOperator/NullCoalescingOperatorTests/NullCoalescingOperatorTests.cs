using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NullCoalescingOperator;

namespace NullCoalescingOperatorTests
{
    [TestClass]
    public class NullCoalescingOperatorTests
    {
        private readonly IncomeCalculator _calculator;
        public NullCoalescingOperatorTests()
        {
            _calculator = new IncomeCalculator();
        }

        [DataTestMethod]
        [DataRow(1000, 12, null, 12000)]
        [DataRow(1000, 12, 3000, 15000)]
        public void WhenCalculatingYearlyIncome_DefaultValueShouldBeUsedIfBonusIsNull(int monthlyIncome, int numberOfMonths, int? extraBonus, int sum)
        {
            var yearlyIncome = _calculator.CalculateYearlyIncome(monthlyIncome, numberOfMonths, extraBonus);
            
            Assert.AreEqual(yearlyIncome, sum);
        }

        [DataTestMethod]
        [DataRow(10, null, 1680)]
        [DataRow(10, 180, 1800)]
        public void WhenCalculatingMonthlyIncome_DefaultValueShouldBeUsedIfNumberOfHoursIsNull(int? hourlyWage, int? numberOfHours, int sum)
        {
            var monthlyIncome = _calculator.CalculateMonthlyIncome(hourlyWage, numberOfHours);
            
            Assert.AreEqual(monthlyIncome, sum);
        }

        [TestMethod]
        public void WhenCalculatingMonthlyIncome_ShouldThrowArgumentNullExceptionIfHourlyWageIsNull()
        {
            int? hourlyWage = null;
            int? numberOfHours = 180;
            
            Assert.ThrowsException<ArgumentNullException>(() => _calculator.CalculateMonthlyIncome(hourlyWage, numberOfHours));
        }
    }
}