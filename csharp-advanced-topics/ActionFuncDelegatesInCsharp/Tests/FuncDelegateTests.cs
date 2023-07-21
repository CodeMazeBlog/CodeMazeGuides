namespace Tests
{
    [TestClass]
    public class FuncDelegateTests
    {
        Func<double> maxSalaryFind = () => { return 50000; };
        Func<double, double, double> SalaryCalculator = new Func<double, double, double>(GetTax);

        public static double GetTax(double netSalary, double taxRate)
        {
            if (netSalary < 0)
                return -1;
            if (taxRate < 0)
                return -2;
            return (double)(netSalary * taxRate);
        }

        [TestMethod]
        public void WhenFuncDelegateMaxSalaryInvoked_ThenItMustReturn50000()
        {
            var result = maxSalaryFind();
            var expected = 50000;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenFuncDelegateSalaryCalculatorInvokedWithNegativeSalary_ThenGetTaxMethodMustBeCalledAndReturnZero()
        {
            var result = SalaryCalculator(-300, 1.23);
            var expected = -1;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenFuncDelegateSalaryCalculatorInvokedWithNegativeRate_ThenGetTaxMethodMustBeCalledAndReturnZero()
        {
            var result = SalaryCalculator(3000, -1.23);
            var expected = -2;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenFuncDelegateSalaryCalculatorInvoked_ThenGetTaxMethodMustBeCalledAndReturnValidValue()
        {
            double result = SalaryCalculator(300, 1.2);
            double expected = 360;
            Assert.AreEqual(expected, result);
        }
    }
}