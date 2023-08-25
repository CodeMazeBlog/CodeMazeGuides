using ReadStringFromResourceFile;

ResourcesManager rmEnglish = new ResourcesManager(@"ReadStringFromResourceFile.Resources.Texts.English");
Console.WriteLine(rmEnglish.GetString("GREETINGS_TEXT"));

var logoff = rmEnglish.GetString("LOGOFF_2");


ResourcesManager rmPortuguese = new ResourcesManager(@"ReadStringFromResourceFile.Resources.Texts.Portuguese");
Console.WriteLine(rmPortuguese.GetResource<string>("GREETINGS_TEXT"));

