using System.Text.RegularExpressions;

namespace SubstringInString
{
    public static class RegexMethod
    {
        public static void Regexmethod() 
        {
            var input = "In programming, understanding the logic behind the code," +
                " writing efficient code, debugging code errors, " +
                "and documenting the code properly are essential skills for any developer.";

            var pattern = @"code";

            var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine("substring found at index " + match.Index + ": " + match.Value);
                }
            }
            else
            {
                Console.WriteLine("not found");
            }
        }
    }
}
