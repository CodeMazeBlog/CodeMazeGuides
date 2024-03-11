using System.Text;

namespace ConvertingStringToCharArrayInCSharp
{
    public static class StringHelper
    {
        public static char[] ConvertStringToCharArray(string inputString)
        {
            return inputString.ToCharArray();
        }

        public static ReadOnlySpan<char> ConvertStringToCharArrayUsingReadOnlySpan(string inputString)
        {
            return inputString.AsSpan();
        }

        public static char ConvertSingleCharacterStringToChar(string inputString)
        {
            return char.Parse(inputString);
        }

        public static char[] ConvertStringArrayToCharArrayUsingLoop(string[] stringArray)
        {
            StringBuilder combinedString = new StringBuilder();

            foreach (string str in stringArray)
            {
                combinedString.Append(str);
            }

            return combinedString.ToString().ToCharArray();
        }

        public static char[] ConvertStringArrayToCharArrayUsingLinq(string[] stringArray)
        {
            return stringArray.SelectMany(s => s.ToCharArray()).ToArray();
        }
    }
}