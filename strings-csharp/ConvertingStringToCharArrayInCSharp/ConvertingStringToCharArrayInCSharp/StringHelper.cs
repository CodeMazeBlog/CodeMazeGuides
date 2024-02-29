using System.Text;

namespace ConvertingStringToCharArrayInCSharp
{
    public static class StringHelper
    {
        public static char[] StringToCharArray(string inputString)
        {
            return inputString.ToCharArray();
        }

        public static ReadOnlySpan<char> StringToCharArrayUsingReadOnlySpan(string inputString)
        {
            var charSpan = inputString.AsSpan();
            return charSpan;
        }

        public static char StringToChar(string inputString)
        {
            if (inputString.Length == 1)
            {
                return inputString[0];
            }

            throw new ArgumentException("Input string must contain exactly one character.");
        }

        public static char[] StringArrayToCharArrayUsingLoop(string[] stringArray)
        {
            StringBuilder combinedString = new StringBuilder();

            foreach (string str in stringArray)
            {
                combinedString.Append(str);
            }

            return combinedString.ToString().ToCharArray();
        }

        public static char[] StringArrayToCharArrayUsingLinq(string[] stringArray)
        {
            return stringArray.SelectMany(s => s.ToCharArray()).ToArray();
        }
    }
}