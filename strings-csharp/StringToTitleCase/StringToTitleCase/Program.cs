using System.Globalization;
using StringToTitleCase;

var textinfo = new CultureInfo("en-US", false).TextInfo;

Console.WriteLine(textinfo.ToTitleCase("a tale oF tWo citIes"));
Console.WriteLine(textinfo.ToTitleCase("harry potter and the Deathly hallows"));

Console.WriteLine(textinfo.ToTitleCase("OLIVER TWIST"));
Console.WriteLine(textinfo.ToTitleCase(textinfo.ToLower("OLIVER TWIST")));
Console.WriteLine(textinfo.ToTitleCase(textinfo.ToLower("THE NASA MISSION")));

Console.WriteLine("a tale oF tWo citIes".ToTitleCaseWithMinorWords(textinfo));
Console.WriteLine("harry potter and the Deathly hallows".ToTitleCaseWithMinorWords(textinfo));

Console.OutputEncoding = System.Text.Encoding.UTF8;
var turkish = new CultureInfo("tr-TR", false).TextInfo;
Console.WriteLine(turkish.ToTitleCase("a tale oF tWo citIes"));
Console.WriteLine(turkish.ToTitleCase("istanbul"));
Console.WriteLine(CultureInfo.InvariantCulture.TextInfo.ToTitleCase("a tale oF tWo citIes"));

Console.WriteLine(textinfo.ToTitleCase("the 2nd edition"));
Console.WriteLine(textinfo.ToTitleCase("my iPhone"));
Console.WriteLine(textinfo.ToTitleCase("mcdonald's menu"));
Console.WriteLine(textinfo.ToTitleCase("x-ray vision"));
