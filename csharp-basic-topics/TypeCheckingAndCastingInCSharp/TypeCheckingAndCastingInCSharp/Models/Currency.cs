namespace TypeCheckingAndCastingInCSharp.Models
{
    public class Currency
    {
        private string _symbol;
        private decimal _value;

        public Currency(string symbol, decimal value)
        {
            _symbol = symbol;
            _value = value;
        }

        public static implicit operator decimal(Currency c) => c._value;
        public static explicit operator Currency(decimal d) => new Currency("$", d);

        public override string ToString() => $"{_symbol}{_value:0.00}";
    }
}
