using HowtoGetaDatabaseRowasJSONUsingDapper.Helper;
using Newtonsoft.Json;

namespace Tests
{
    public class JsonHelperUnitTest
    {
        [Fact]
        public void WhenConvertingToJson_ThenReturnSerializeObjectToJsonString()
        {
            // Arrange
            dynamic dynamicData = new { Id = 1, Name = "Mazda", Make = "Tokyo", Model = "MD-233H", Color = "Japan", Year = 2022 };

            // Act
            string jsonString = JsonHelper.ConvertToJson(dynamicData);
            dynamic deserializedData = JsonConvert.DeserializeObject(jsonString);

            // Assert
            Assert.Equal("Mazda", deserializedData.Name.ToString());
            Assert.Equal(2022, (int)deserializedData.Year);
        }
    }
}
