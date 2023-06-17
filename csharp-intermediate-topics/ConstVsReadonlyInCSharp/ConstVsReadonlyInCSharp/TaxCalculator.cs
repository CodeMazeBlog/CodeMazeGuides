namespace ConstVsReadonlyInCSharp
{
    public class TaxCalculator
    {
        private readonly decimal _countryVAT;
        private readonly decimal _euroToDollarConversionRate = (decimal)1.08;
        private readonly MathCalculator _calculator = new MathCalculator();


        public TaxCalculator(decimal countryVAT)
        {
            _countryVAT = countryVAT;
        }

        public decimal CalculateCountryVatInEuro(decimal productValue)
        {
            return _calculator.Multiply(productValue, _countryVAT);
        }

        public decimal CalculateCountryVatInDollars(decimal productValue)
        {
            return CalculateCountryVatInEuro(productValue) * _euroToDollarConversionRate;
        }
    }
}
