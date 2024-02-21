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
            var pattern = @"-?\d+(\.\d+)?";

            var matches = Regex.Matches(inputString, pattern);

            foreach (Match match in matches)
            {
                if (double.TryParse(match.Value, out double parsedNumber))
                {
                    number = parsedNumber;
                }
            }
            return number;
        }

        public static double ExtractNumberUsingLinqAndCharIsDigit(string inputString)
        {
            var result = new string(inputString.Where(c => char.IsDigit(c) || c == '.' || c == '-').ToArray());

            return string.IsNullOrEmpty(result) ? 0 : double.Parse(result);
        }

        public static double ExtractNumberUsingStringBuilderAndCharIsDigit(string inputString)
        {
            var result = new StringBuilder();

            foreach (var c in inputString)
            {
                if (char.IsDigit(c) || c == '.' || c == '-')
                {
                    result.Append(c);
                }
            }

            return result.Length > 0 ? double.Parse(result.ToString()) : 0;
        }
    }
}
