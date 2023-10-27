using ActionAndFuncDelegates;

namespace Tests
{
    [TestClass]
    public class TestTaxCalculations
    {
        [TestMethod]
        public void WhenTaxableIncome_ThenCalculateCorrectIncomeTax()
        {
            var taxableIncome = 130000M;
            var expectedTaxLiability = 39000.00M;
            var taxLiability = Program.CalculateIncomeTax(taxableIncome);

            Assert.AreEqual(expectedTaxLiability, taxLiability);
        }

        [TestMethod]
        public void WhenTotalSales_ThenCalculateCorrectSalesTax()
        {
            var totalSales = 100000M;
            var expectedTaxLiability = 9250.00M;
            var taxLiability = Program.CalculateSalesTax(totalSales);

            Assert.AreEqual(expectedTaxLiability, taxLiability);
        }

        [TestMethod]
        public void WhenPropertyValue_ThenCalculateCorrectPropertyTax()
        {
            var propertyValue = 100000M;
            var expectedTaxLiability = 581.25M;
            var taxLiability = Program.CalculatePropertyTax(propertyValue);

            Assert.AreEqual(expectedTaxLiability, taxLiability);
        }
    }
}