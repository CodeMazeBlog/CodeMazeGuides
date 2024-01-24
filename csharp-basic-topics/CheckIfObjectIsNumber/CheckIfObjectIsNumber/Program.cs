namespace CheckIfObjectIsNumber
{
    public class Program
    {
        public static bool CheckIfIntegerWithEqualityOperator(object value)
        {
            var isInteger = value.GetType() == typeof(int);
            return isInteger;
        }

        public static float CheckIfFloatWithExplicitCasting(object value)
        {
            float _float = (float)value;
            return _float;
        }

        public static short CheckIfShortUsingConvert(object value)
        {
            short _short = Convert.ToInt16(value);
            return _short;
        }

        public static bool CheckIfFloatWithIsOperator(object value)
        {
            if(value is float)
            {
                return true;
            }

            return false;
        }

        public static int ConvertToIntWithAsOperator(object value)
        {
            var amount =  value as int?;
            if (amount == null) return 0;
            return amount.Value;
        }

        public static double CalculateAllTaxesIncludedPrice(object tax)
        {
            double price = 28;
            if (tax is double vat)
            {
                price = price + (price * vat)/100;
            }
            return price;
        }

        static void Main(string[] args)
        {
            var boolResult = CheckIfIntegerWithEqualityOperator(123);    // Returns True 
            Console.WriteLine(boolResult);
            boolResult = CheckIfIntegerWithEqualityOperator(456d);       // Returns False
            Console.WriteLine(boolResult);
            boolResult = CheckIfIntegerWithEqualityOperator(0);          // Returns True
            Console.WriteLine(boolResult);

            var floatResult = CheckIfFloatWithExplicitCasting(-2.5f);
            Console.WriteLine(floatResult);   // Returns -2.5

            try
            {
                floatResult = CheckIfFloatWithExplicitCasting((long)5);  // System.InvalidCastException
            }
            catch (InvalidCastException) { Console.WriteLine(typeof(InvalidCastException)); }
            
            try
            {
                floatResult = CheckIfFloatWithExplicitCasting(5.0d);         // System.InvalidCastException
            }
            catch (InvalidCastException) { Console.WriteLine(typeof(InvalidCastException)); }           

            var convertResult = CheckIfShortUsingConvert((long)5);
            Console.WriteLine(convertResult);       // Returns 5 
            convertResult = CheckIfShortUsingConvert(19);
            Console.WriteLine(convertResult);       // Returns 19
            convertResult = CheckIfShortUsingConvert(12.54f);
            Console.WriteLine(convertResult);       // Returns 13           
            try
            {
                convertResult = CheckIfShortUsingConvert(Decimal.MaxValue); // System.OverflowException       
            }
            catch (OverflowException) { Console.WriteLine(typeof(OverflowException)); }

            var isFloat = CheckIfFloatWithIsOperator(6.99f);
            Console.WriteLine(isFloat);     // Returns True
            isFloat = CheckIfFloatWithIsOperator(Math.PI);
            Console.WriteLine(isFloat);     // Returns False

            var intValue = ConvertToIntWithAsOperator(19);
            Console.WriteLine(intValue);     // Returns 19
            intValue = ConvertToIntWithAsOperator(.25);
            Console.WriteLine(intValue);     // Returns 0

            object value = "123";
            var isNumber = value.IsNumber();
            Console.WriteLine(isNumber);    // Returns False
            value = 123;
            isNumber = value.IsNumber();
            Console.WriteLine(isNumber);    // Returns True

            var price = CalculateAllTaxesIncludedPrice(10.0);
            Console.WriteLine(price);       // Returns 30.8
            price = CalculateAllTaxesIncludedPrice(20);
            Console.WriteLine(price);       // Returns 28
        }
    }
}

public static class Extensions
{
    public static bool IsNumber(this object value)
    {
        return value is sbyte
                || value is byte
                || value is short
                || value is ushort
                || value is int
                || value is uint
                || value is long
                || value is ulong
                || value is nint
                || value is nuint
                || value is float
                || value is double
                || value is decimal;
    }
}