using ReadStringFromResourceFile;

var rmEnglish = new ResourcesManager(@"ReadStringFromResourceFile.Resources.Texts.English");
Console.WriteLine(rmEnglish.GetString("GREETINGS_TEXT"));

var logoff = rmEnglish.GetString("LOGOFF_2");
if (string.IsNullOrEmpty(logoff))
    Console.WriteLine("Resource LOGOFF_2 doesn´t exist!");

var rmPortuguese = new ResourcesManager(@"ReadStringFromResourceFile.Resources.Texts.Portuguese");
Console.WriteLine(rmPortuguese.GetResource<string>("GREETINGS_TEXT"));

