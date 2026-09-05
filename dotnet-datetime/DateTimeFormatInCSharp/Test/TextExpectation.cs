using System.Globalization;
using System.Linq;

namespace Test
{
    // The character a culture puts between the time and its AM/PM designator comes from the
    // host's ICU data, not from the .NET version: en-US emits an ordinary space (U+0020) on
    // some hosts and a narrow no-break space (U+202F) on others, so the same assertion can
    // pass on a Windows desktop and fail in a Linux container. See dotnet/runtime#96022,
    // closed "working as designed" ("culture formats are provided by the OS and change from
    // time to time").
    //
    // Every expectation in this project is therefore compared after normalising Unicode space
    // separators to a plain space. The alternative -- pasting an invisible character into a
    // string literal -- makes the expected value unreadable and still only works on one host.
    internal static class TextExpectation
    {
        public static string NormalizeSpaces(string value) =>
            string.Concat(value.Select(character =>
                char.GetUnicodeCategory(character) == UnicodeCategory.SpaceSeparator ? ' ' : character));
    }
}
