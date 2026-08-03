using Newtonsoft.Json;
using OrderPropertyJsonInCSharp;
using OrderPropertyJsonInCSharp.Converters;
using OrderPropertyJsonInCSharp.Models;
using OrderPropertyJsonInCSharp.Resolvers;
using OrderPropertyJsonInCSharp.Serializers;

namespace Tests
{
    [TestClass]
    public class OrderPropertyJsonUnitTest
    {
        [TestMethod]
        public void WhenUsingJsonPropertyOrder_ThenReturnOrderedProperties()
        {
            var json = MicrosoftSerializer.Serialize(Program.Car);
            
            var expectedResult = $"{{{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"NumberOfDoors\": 4,{Environment.NewLine}  \"Manufacturer\": \"Fiat\"{Environment.NewLine}}}";
            
            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenUsingNewtonsoftJsonPropertyOrder_ThenReturnOrderedProperties()
        {
            var json = NewtonsoftSerializer.Serialize(Program.Car);

            var expectedResult = $"{{{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"NumberOfDoors\": 4,{Environment.NewLine}  \"Manufacturer\": \"Fiat\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenUsingJsonConverter_ThenReturnOrderedProperties()
        {
            var json = MicrosoftSerializer.Serialize(Program.Animal, new MicrosoftOrderedPropertiesConverter<Animal>());

            var expectedResult = $"{{{Environment.NewLine}  \"Age\": 3,{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Name\": \"Miau\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenUsingNewtonsoftJsonConverter_ThenReturnOrderedProperties()
        {
            var json = NewtonsoftSerializer.Serialize(Program.Animal, new NewtonsoftOrderedPropertiesConverter<Animal>());

            var expectedResult = $"{{{Environment.NewLine}  \"Age\": 3,{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Name\": \"Miau\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenUsingNewtonsoftContractResolver_ThenReturnOrderedProperties()
        {
            var json = NewtonsoftSerializer.Serialize(Program.Animal, new OrderedPropertiesContractResolver());

            var expectedResult = $"{{{Environment.NewLine}  \"Age\": 3,{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Name\": \"Miau\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenUsingMicrosoftTypeInfoResolver_ThenReturnOrderedProperties()
        {
            var json = MicrosoftSerializer.Serialize(Program.Animal, new OrderedPropertiesJsonTypeInfoResolver());

            var expectedResult = $"{{{Environment.NewLine}  \"Age\": 3,{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Name\": \"Miau\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }
    }
}