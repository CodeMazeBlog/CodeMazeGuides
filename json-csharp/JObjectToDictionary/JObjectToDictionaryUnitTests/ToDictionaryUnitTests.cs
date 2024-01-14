using JObjectToDictionary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace JObjectToDictionaryUnitTests
{
    [TestClass]
    public class ToDictionaryUnitTests
    {
        JObject person = new(
            new JProperty("Name", "John Smith"),
            new JProperty("BirthDate", new DateTime(1983, 3, 20)),
            new JProperty("Hobbies", new JArray("Play football", "Programming")),
            new JProperty("Extra", new JObject(
                new JProperty("Age", 27),
                new JProperty("Phone", new JArray(1, 2, 3))
            ))
        );

        [TestMethod]
        public void WhenConvertingToDictionaryUsingTraditionalIteration_ThenDictionaryIsCorrectlyGenerated()
        {
            var result = JObjectConverter.ConvertJObjectToDictionary(person);

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));

            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void WhenConvertingToDictionaryUsingNewtonsoftJson_ThenDictionaryIsCorrectlyGenerated()
        {
            var result = JObjectConverter.ConvertUsingNewtonsoftJson(person);

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));

            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void WhenConvertingToDictionaryUsingLinq_ThenDictionaryIsCorrectlyGenerated()
        {
            var result = JObjectConverter.ConvertUsingLinq(person);

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));

            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void WhenConvertingToDictionaryUsingExtensionMethod_ThenDictionaryIsCorrectlyGenerated()
        {
            var result = person.ToDictionary();

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));

            Assert.AreEqual(4, result.Count);
        }
    }
}