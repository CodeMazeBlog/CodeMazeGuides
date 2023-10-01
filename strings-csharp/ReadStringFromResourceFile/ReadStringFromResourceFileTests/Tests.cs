using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Resources;

namespace Tests;

[TestClass]
public class Tests 
{
    const string HELLO_TEXT = "Hello, how are you?";
    readonly ResourceManager _rmEnglish = new ResourceManager(@"ReadStringFromResourceFile.Resources.Texts.English", 
        typeof(ReadStringFromResourceFile.Resources.Texts.English).Assembly);

    [TestMethod]
    public void GivenEnglishResourceFileHandler_WhenUsingResourceManager_ThenResourceStringFetchedIsCorrect()
    {
        var greetingsText = _rmEnglish.GetString("GREETINGS_TEXT");
        
        Assert.AreEqual(HELLO_TEXT, greetingsText);
    }

    [TestMethod]
    public void GivenResourceFile_WhenFetchingResourceDirectly_ThenResourceStringFetchedIsCorrect()
    {
        var greetingsText = ReadStringFromResourceFile.Resources.Texts.English.GREETINGS_TEXT;

        Assert.AreEqual(HELLO_TEXT, greetingsText);
    }
}
