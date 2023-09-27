using ConstVsReadonlyInCSharp;

namespace Tests
{
    public class TaxCalculatorUnitTests
    {
        private TaxCalculator _taxCalculator = new TaxCalculator(0.20M);

        [Fact]
        public void WhenCalculatingTaxForValue15InEuros_ThenReturn3()
        {
            var result = _taxCalculator.CalculateCountryVatInEuro(15);

            Assert.Equal(3, result, 5);
        }

        [Fact]
        public void WhenCalculatingTaxForValue15InDollars_ThenReturn3_24()
        {
            var result = _taxCalculator.CalculateCountryVatInDollars(15);

            Assert.Equal(3.24M, result, 5);
        }
    }
}
