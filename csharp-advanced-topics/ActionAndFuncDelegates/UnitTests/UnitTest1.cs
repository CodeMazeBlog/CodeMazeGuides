using ActionAndFuncDelegates;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WhenTaxableIncome_ThenCalculateCorrectIncomeTax()
        {
            decimal taxableIncome = 130000M;
            decimal expectedTaxLiability = 39000.00M;
            decimal taxLiability = Program.CalculateIncomeTax(taxableIncome);

            Assert.AreEqual(expectedTaxLiability, taxLiability);
        }

        [TestMethod]
        public void WhenTotalSales_ThenCalculateCorrectSalesTax()
        {
            decimal totalSales = 100000M;
            decimal expectedTaxLiability = 9250.00M;
            decimal taxLiability = Program.CalculateSalesTax(totalSales);

            Assert.AreEqual(expectedTaxLiability, taxLiability);
        }

        [TestMethod]
        public void WhenPropertyValue_ThenCalculateCorrectPropertyTax()
        {
            decimal propertyValue = 100000M;
            decimal expectedTaxLiability = 581.25M;
            decimal taxLiability = Program.CalculatePropertyTax(propertyValue);

            Assert.AreEqual(expectedTaxLiability, taxLiability);
        }
    }
}