using ComparingTwoJsonObjects;

namespace Tests
{
    public class ComparingTwoJsonObjectsUnitTest
    {
        private readonly JsonComparison _jsonComparison;

        public ComparingTwoJsonObjectsUnitTest()
        {
            _jsonComparison= new JsonComparison();
        }

        [Theory]
        [InlineData("Plain Objects Result", "The plain json objects are equal")]
        [InlineData("Nested Objects Result","The plain and nested json objects are not equal")]
        public void WhenJTokenDeepEqualsIsUsed_ThenCompareObjectsAndPopulateDictionary(string key, string expectedValue)
        {
            var result = _jsonComparison.CompareJsonObjectsUsingDeepEquals();

            Assert.Equal(expectedValue, result[key]);
        }

        [Theory]
        [InlineData("Plain Objects Result", "The two deserialized plain json objects are equal")]
        [InlineData("Nested Objects Result", "The plain and nested deserialized objects are not equal")]
        public void WhenComparingDeserializedObjects_ThenCompareObjectsAndPopulateDictionary(string key, string expectedValue)
        {   
            var result = _jsonComparison.CompareDeserializedJsonObjects();

            Assert.Equal(expectedValue, result[key]);
        }

        [Theory]
        [InlineData("Plain Objects Result", "The plain JSON objects are equal")]
        [InlineData("Nested Objects Result", "The plain and nested json objects are not equal")]
        public void WhenUsingLinqForComparison_ThenCompareObjectsAndPopulateDictionary(string key, string expectedValue)
        {
            var result = _jsonComparison.CompareJsonObjectsUsingLinq();

            Assert.Equal(expectedValue, result[key]);
        }
    }
}
