using System.Reflection;
using System.Text.RegularExpressions;

namespace FindAllPositionsOfAString;

public static partial class JuliusCaesarText
{
    private static string value = string.Empty;

    public static string Read()
    {
        if (value != string.Empty)
            return value;

        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "FindAllPositionsOfAString.Resources.julius-caesar.txt";

        using (Stream stream = assembly.GetManifestResourceStream(resourceName)!)
        using (var reader = new StreamReader(stream))
            value = reader.ReadToEnd();

        value = new string(value.Select(c => char.IsLetterOrDigit(c) ? c : ' ').ToArray());
        value = RemoveMultipleSpaces().Replace(value, " ");

        return value;
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex RemoveMultipleSpaces();
}
