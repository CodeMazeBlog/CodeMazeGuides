using ReadStringFromResourceFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests 
    {
        readonly ResourcesManager _rmEnglish = new ResourcesManager(@"ReadStringFromResourceFile.Resources.Texts.English");
        readonly ResourcesManager _rmPortuguese = new ResourcesManager(@"ReadStringFromResourceFile.Resources.Texts.Portuguese");

        [TestMethod]
        public void GivenEnglishResourceFileHandler_WhenRunIsCalled_ThenResourceStringFetchedIsCorrect()
        {
            var greetingsText = _rmEnglish.GetString("GREETINGS_TEXT");
            
            Assert.AreEqual("Hello, how are you?", greetingsText);
        }

        [TestMethod]
        public void GivenPortugueseResourceFileHandler_WhenRunIsCalled_ThenResourceStringFetchedIsCorrect()
        {
            var greetingsText = _rmPortuguese.GetString("GREETINGS_TEXT");

            Assert.AreEqual("Olá, como está?", greetingsText);
        }

        [TestMethod]
        public void GivenPortugueseResourceFileHandler_WhenInstantiatingInvalidResourceBasePath_ThenSetIsValidAsFalse()
        {
            var localResourceFile = new ResourcesManager(@"ReadStringFromResourceFile.Resources.Texts.Portuguese_Invalid");

            Assert.IsFalse(localResourceFile.IsValid);
        }

        [TestMethod]
        public void GivenPortugueseResourceFileHandler_WhenRequestingInvalidResource_ThenReturnsInvalidResourceItem()
        {
            var greetingsText = _rmPortuguese.GetString("GREETINGS_DONT_EXIST");

            Assert.AreEqual(0, greetingsText.Length);
        }
    }
}
