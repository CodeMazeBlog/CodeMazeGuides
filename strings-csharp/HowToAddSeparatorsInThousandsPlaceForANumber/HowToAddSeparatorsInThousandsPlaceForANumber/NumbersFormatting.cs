using System.Globalization;

namespace HowToAddSeparatorsInThousandsPlaceForANumber
{
    public static class NumbersFormatting
    {
        private static readonly double _balance = 2154002.535;

        public static string GetBalanceUsingTheStringFormatMethod()
        {
            return string.Format("Your account balance is: {0}", _balance);
        }

        public static string GetBalanceUsingTheStringFormatMethodAndACultureInfo(CultureInfo cultureInfo)
        {
            return string.Format("Your account balance is: {0}", _balance, cultureInfo);
        }
        public static string GetBalanceUsingTheStringFormatMethodACultureInfoAndSpecifiers(int? decimalsCount, CultureInfo cultureInfo)
        {
            return decimalsCount switch
            {
                0 => string.Format("Your account balance is: {0:n0}", _balance, cultureInfo),
                4 => string.Format("Your account balance is: {0:n4}", _balance, cultureInfo),
                _ => string.Format("Your account balance is: {0:n}", _balance, cultureInfo),
            };
        }

        public static string GetBalanceUsingTheToStringMethod(string specifier, CultureInfo? cultureInfo)
        {
            var formatedBalance = _balance.ToString(specifier, cultureInfo);
            return "Your account balance is: " + formatedBalance;
        }

        public static string GetBalanceUsingStringInterpolation(int? digitsCount)
        {
            return digitsCount switch
            {
                4 => $"Your account balance is: {_balance:n4}",
                _ => $"Your account balance is: {_balance}",
            };
        }

        public static string GetBalanceUsingStringInterpolationWithCultureInfo(string specifier, CultureInfo cultureInfo)
        {
            var formatedBalance = _balance.ToString(specifier, cultureInfo);

            return $"Your account balance is: {formatedBalance}";
        }
    }
}
