using System.Text;
using System.Text.RegularExpressions;

namespace CheckNumberInString
{
    public static class ExtractNumber
    {
        public static double ExtractNumberUsingRegEx(string inputString)
        {
            var number = 0.0;

            // Regex pattern to match decimal numbers with optional minus sign
            string pattern = @"-?\d+(\.\d+)?";

            MatchCollection matches = Regex.Matches(inputString, pattern);

            foreach (Match match in matches)
            {
                if (double.TryParse(match.Value, out double parsedNumber))
                {
                    number = parsedNumber;
                }
            }
            return number;
        }

        public static int ExtractNumberUsingLinqAndCharIsDigit(string inputString)
        {
            string result = new string(inputString.Where(char.IsDigit).ToArray());

            return string.IsNullOrEmpty(result) ? 0 : int.Parse(result);
        }

        public static int ExtractNumberUsingStringBuilderAndCharIsDigit(string inputString)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    result.Append(c);
                }
            }

            return result.Length > 0 ? int.Parse(result.ToString()) : 0;
        }
    }
}
