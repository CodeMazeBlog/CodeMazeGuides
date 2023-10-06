using System.Reflection;
using System.Resources;
using ReadStringFromResourceFile.Resources.Texts;

var rmEnglish 
    = new ResourceManager(@"ReadStringFromResourceFile.Resources.Texts.English", 
    Assembly.GetExecutingAssembly());
Console.WriteLine(rmEnglish.GetString("GREETINGS_TEXT"));

Console.WriteLine(English.GREETINGS_TEXT);
