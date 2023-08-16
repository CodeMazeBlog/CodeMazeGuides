namespace ConstVsReadonlyInCSharp
{
    public class TaxCalculator
    {
        public readonly decimal _countryVAT;
        public readonly decimal _euroToDollarConversionRate = 1.08M;
        private readonly MathCalculator _calculator = new MathCalculator();

        public TaxCalculator(decimal countryVAT)
        {
            _countryVAT = countryVAT;
        }

        public decimal CalculateCountryVatInEuro(decimal productValue) 
            => _calculator.Multiply(productValue, _countryVAT);

        public decimal CalculateCountryVatInDollars(decimal productValue) 
            => CalculateCountryVatInEuro(productValue) * _euroToDollarConversionRate;
    }
}
