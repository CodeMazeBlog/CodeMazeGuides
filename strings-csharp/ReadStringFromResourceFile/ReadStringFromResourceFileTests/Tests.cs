using ReadStringFromResourceFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests 
    {
        readonly ResourcesManager rmEnglish = new(@"ReadStringFromResourceFile.Resources.Texts.English");
        readonly ResourcesManager rmPortuguese = new(@"ReadStringFromResourceFile.Resources.Texts.Portuguese");

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

        [TestMethod]
        public void GivenPortugueseResourceFileHandler_WhenInstantiatingInvalidResourceBasePath_ThenSetIsValidAsFalse()
        {
            ResourcesManager localResourceFile = new(@"ReadStringFromResourceFile.Resources.Texts.Portuguese_Invalid");

            Assert.AreEqual(false, localResourceFile.IsValid);
        }

        [TestMethod]
        public void GivenPortugueseResourceFileHandler_WhenRequestingInvalidResource_ThenReturnsInvalidResourceItem()
        {
            var greetingsText = rmPortuguese.GetString("GREETINGS_DONT_EXIST");

            Assert.AreEqual(0, greetingsText.Length);
        }
    }
}
