using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfObjectIsNumber
{
    public static class Methods
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
            if (value is float)
            {
                return true;
            }

            return false;
        }

        public static int ConvertToIntWithAsOperator(object value)
        {
            var amount = value as int?;
            if (amount == null) return 0;

            return amount.Value;
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
