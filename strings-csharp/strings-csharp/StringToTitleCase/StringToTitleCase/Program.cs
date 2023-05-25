using System;
using System.Globalization;

namespace StringToTitleCase
{
    class Program
    {
        static void Main(string[] args)
        {
            var textinfo = new CultureInfo("en-US", false).TextInfo;

            var textInfo = CultureInfo.CurrentCulture.TextInfo;

            Console.WriteLine(textinfo.ToTitleCase("a tale oF tWo citIes"));

            Console.WriteLine(textinfo.ToTitleCase("harry potter and the Deathly hallows"));

            Console.WriteLine(textinfo.ToTitleCase("OLIVER TWIST".ToLower()));
        }
    }
}
