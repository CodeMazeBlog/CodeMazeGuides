namespace ConstVsReadonlyInCSharp
{
    public class TaxCalculator
    {
        private readonly double _countryVAT;
        private readonly double _euroToDollarConvertionRate = 1.08;
        private readonly MathCalculator _calculator = new MathCalculator();


        public TaxCalculator(double countryVAT)
        {
            _countryVAT = countryVAT;
        }

        public double CalculateCountryVatInEuro(double productValue)
        {
            return _calculator.Multiply(productValue, _countryVAT);
        }

        public double CalculateCountryVatInDollars(double productValue)
        {
            return CalculateCountryVatInEuro(productValue) * _euroToDollarConvertionRate;
        }
    }
}
