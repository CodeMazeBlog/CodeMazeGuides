using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryTests
{
    [TestClass]
    public class DictionaryGetValueByIndexTests
    {
        [TestMethod]
        public void GivenDictionary_WhenAccessedByIndex_ThenReturnElement()
        {
            var capitals = new Dictionary<string, string>()
            {
                {"Turkey", "Ankara"},
                {"UK", "London"},
                {"USA", "Washington"}
            };

            var element = capitals.ElementAt(2);

            Assert.AreEqual( "USA", element.Key);
        }


        [TestMethod]
        public void GivenDictionary_WhenAccessedByIndex_ThenReturnElementValue()
        {
            var capitals = new Dictionary<string, string>()
            {
                {"Turkey", "Ankara"},
                {"UK", "London"},
                {"USA", "Washington"}
            };

            var element = capitals.ElementAt(2);

            Assert.AreEqual(capitals["USA"], element.Value);
        }
    }
}