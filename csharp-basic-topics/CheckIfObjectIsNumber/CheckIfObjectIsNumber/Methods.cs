namespace CheckIfObjectIsNumber
{
    public static class Methods
    {
        public static bool CheckIfIntegerWithEqualityOperator(object value) => value.GetType() == typeof(int);

        public static bool CheckIfFloatWithExplicitCast(object value)
        {
            try
            {
                var result = (float)value;
                Console.WriteLine(result);

                return true;
            }
            catch(InvalidCastException)
            {
                Console.WriteLine(typeof(InvalidCastException));

                return false;
            }
        }

        public static bool CheckIfShortUsingConvert(object value)
        {
            try
            {
                var result = Convert.ToInt16(value);
                Console.WriteLine(result);

                return true;
            }
            catch (OverflowException)
            {
                Console.WriteLine(typeof(OverflowException));

                return false;
            }
            catch (FormatException)
            {
                Console.WriteLine(typeof(FormatException));
                return false;
            }
        }

        public static bool CheckIfFloatWithIsOperator(object value) => value is float;

        public static bool CheckIfIntWithAsOperator(object value)
        {
            var amount = value as int?;
            if(amount is not null)
                Console.WriteLine(amount);
            else
                Console.WriteLine("null");

            return amount is not null;
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
