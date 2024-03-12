using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CheckNumberInString
{
    public static partial class ExtractNumber
    {
        // Define valid numerical characters including digits, minus sign, and decimal point
        private static readonly char[] validNumericalValues = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '.' };

        [GeneratedRegex(@"-?\d+(\.\d+)?", RegexOptions.Compiled)]
        private static partial Regex NumberRegex();
        public static string ExtractNumberUsingRegEx(string inputString)
        {
            var extractedNumbers = new List<double>();

            var matches = NumberRegex().Matches(inputString);

            foreach (Match match in matches)
            {
                if (double.TryParse(match.Value, out var parsedNumber))
                {
                    extractedNumbers.Add(parsedNumber);
                }
            }

            return String.Join(",", extractedNumbers);
        }
        
        public static string ExtractNumbersUsingLinq(string inputString)
        {
            return new string(inputString
                .Where(c => char.IsBetween(c, '0', '9') || c == '.' || c == '-' || char.IsWhiteSpace(c))
                .ToArray());
        }
        
        public static string ExtractNumberUsingStringBuilder(string inputString)
        {
            var numbers = new List<double>();
            var currentNumber = new StringBuilder();
            var isInsideNumber = false;

            foreach (var c in inputString)
            {
                if (char.IsBetween(c, '0', '9') || c == '.' || c == '-')
                {
                    currentNumber.Append(c);
                    isInsideNumber = true;
                }
                else if (isInsideNumber)
                {
                    AddNumberToList(currentNumber.ToString(), numbers);
                    currentNumber.Clear();
                    isInsideNumber = false;
                }
            }

            if (currentNumber.Length > 0)
            {
                AddNumberToList(currentNumber.ToString(), numbers);
            }

            return String.Join(",", numbers);
        }

        public static string ExtractNumberUsingSpan(string inputString)
        {
            var numbers = new List<double>();

            var inputStringSpan = inputString.AsSpan();
            while (true)
            {
                var startIndex = inputStringSpan.IndexOfAny(validNumericalValues);
                if (startIndex == -1) break; 

                inputStringSpan = inputStringSpan.Slice(startIndex);
                var endIndex = inputStringSpan.IndexOfAnyExcept(validNumericalValues);

                if (endIndex == -1)
                {
                    AddNumber(inputStringSpan, numbers);
                    break;
                }

                AddNumber(inputStringSpan.Slice(0, endIndex), numbers);
                inputStringSpan = inputStringSpan.Slice(endIndex);
            }

            return String.Join(",", numbers);
        }
        
        private static void AddNumberToList(string numberString, ICollection<double> numbers)
        {
            if (double.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
            {
                numbers.Add(number);
            }
        }

        private static void AddNumber(ReadOnlySpan<char> numberSpan, List<double> numbers)
        {
            if (double.TryParse(numberSpan.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                numbers.Add(result);
        }
    }
}
