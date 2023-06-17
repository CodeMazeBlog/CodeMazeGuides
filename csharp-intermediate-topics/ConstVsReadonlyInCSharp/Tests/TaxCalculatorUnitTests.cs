using ConstVsReadonlyInCSharp;

namespace Tests
{
    public class TaxCalculatorUnitTests
    {
        private TaxCalculator _taxCalculator = new TaxCalculator((decimal)0.20);

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

            Assert.Equal((decimal)3.24, result, 5);
        }
    }
}
