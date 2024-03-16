using System.Text;

namespace ConvertingStringToCharArrayInCSharp;

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
    var combinedString = new StringBuilder();

    foreach (var str in stringArray)
    {
        combinedString.Append(str);
    }

    var result = new char[combinedString.Length];
    combinedString.CopyTo(0, result, 0, result.Length);

    return result;
}

    public static char[] ConvertStringArrayToCharArrayUsingLinq(string[] stringArray)
    {
        return stringArray.SelectMany(s => s.ToCharArray()).ToArray();
    }
}