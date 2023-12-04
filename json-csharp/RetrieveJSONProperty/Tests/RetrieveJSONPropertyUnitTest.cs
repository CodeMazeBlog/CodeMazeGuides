using RetrieveJSONProperty.Helper;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using RetrieveJSONProperty.DTOs;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void GivenObjectWithJsonPropertyAttribute_WhenRetrievalUsingReflection_ThenPrintJsonPropertyNames()
        {
            // Arrange
            var testObject = new TestObject { Property1 = "Value1", Property2 = "Value2" };
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            JsonHelper.RetrievalUsingReflection(testObject);

            // Assert
            string output = consoleOutput.ToString().Trim();
            StringAssert.Contains("prop1", output);
            StringAssert.Contains("prop2", output);
        }

     

        public class TestObject2
        {
            public string Name { get; set; }

            public string Area { get; set; }
        }

        public class TestObject
        {
            [JsonProperty("prop1")]
            public string Property1 { get; set; }

            [JsonProperty("prop2")]
            public string Property2 { get; set; }
        }

        [Test]
        public void Given_ObjectWithJsonPropertyAttributes_WhenGetJsonPropertyNames_ThenReturnPropertyNames()
        {
            // Arrange
            var testObject = new TestObjectWithAttributes();

            // Act
            string[] result = JsonTextImplementation.GetJsonPropertyNames(testObject);

            // Assert
            string[] expected = { "FirstName", "LastName", "Age" };
            Assert.AreEqual(expected, result);
        }

        public class TestObjectWithAttributes
        {
            [JsonPropertyName("FirstName")]
            public string Name { get; set; }

            [JsonPropertyName("LastName")]
            public string Surname { get; set; }

            public int Age { get; set; }
        }

        [Test]
        public void Given_ProductObject_When_SerializeUsingPascalCaseContractResolver_Then_JsonShouldBeInPascalCase()
        {
            // Arrange
            var resolver = new PascalCaseContractResolver();
            var settings = new JsonSerializerSettings
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented
            };

            var product = new Product
            {
                ProductId = "123",
                ProductName = "Widget"
            };

            // Act
            var json = JsonConvert.SerializeObject(product, settings);

            // Assert
            string expectedJson = @"{
  ""ProductId"": ""123"",
  ""ProductName"": ""Widget""
}";
            Assert.AreEqual(expectedJson, json);
        }
    }
}
