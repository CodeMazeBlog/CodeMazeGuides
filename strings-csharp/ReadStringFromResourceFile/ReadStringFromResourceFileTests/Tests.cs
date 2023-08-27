using ReadStringFromResourceFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests 
    {
        ResourcesManager rmEnglish;
        ResourcesManager rmPortuguese;

        public Tests()
        {
            rmEnglish = new ResourcesManager(@"ReadStringFromResourceFile.Resources.Texts.English");
            rmPortuguese = new ResourcesManager(@"ReadStringFromResourceFile.Resources.Texts.Portuguese");
        }

        [TestMethod]
        public void GivenEnglishResourceFileHandler_WhenRunIsCalled_ThenResourceStringFetchedIsCorrect()
        {
            var greetingsText = rmEnglish.GetString("GREETINGS_TEXT");
            
            Assert.AreEqual("Hello, how are you?", greetingsText);
        }

        [TestMethod]
        public void GivenPortugueseResourceFileHandler_WhenRunIsCalled_ThenResourceStringFetchedIsCorrect()
        {
            var greetingsText = rmPortuguese.GetString("GREETINGS_TEXT");

            Assert.AreEqual("Olá, como está?", greetingsText);
        }
    }
}
