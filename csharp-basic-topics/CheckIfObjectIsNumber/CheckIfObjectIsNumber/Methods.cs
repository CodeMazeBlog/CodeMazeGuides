namespace CheckIfObjectIsNumber
{
    public static class Methods
    {
        public static bool CheckIfIntegerWithEqualityOperator(object value) => value.GetType() == typeof(int);

        public static float CheckIfFloatWithExplicitCasting(object value) => (float)value;

        public static short CheckIfShortUsingConvert(object value) => Convert.ToInt16(value);

        public static bool CheckIfFloatWithIsOperator(object value) => value is float;

        public static int ConvertToIntWithAsOperator(object value)
        {
            var amount = value as int?;

            return amount ?? 0;
        }

        public static double CalculateAllTaxesIncludedPrice(object tax)
        {
            double price = 28;
            if (tax is double vat)
            {
                price += (price * vat) / 100;
            }

            return price;
        }
    }
}
