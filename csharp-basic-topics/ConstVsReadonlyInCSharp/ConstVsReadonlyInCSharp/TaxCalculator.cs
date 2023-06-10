namespace ConstVsReadonlyInCSharp
{
    public class TaxCalculator
    {
        private readonly double countryVAT;
        private readonly double euroToDollarConvertionRate = 1.08;

        private readonly MathCalculator calculator = new MathCalculator();


        public TaxCalculator(double countryVAT)
        {
            this.countryVAT = countryVAT;
        }

        public double CalculateCountryVatInEuro(double productValue)
        {
            return calculator.Multiply(productValue, countryVAT);
        }

        public double CalculateCountryVatInDollars(double productValue)
        {
            return CalculateCountryVatInEuro(productValue) * euroToDollarConvertionRate;
        }
    }
}
