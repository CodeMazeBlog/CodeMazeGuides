using ReturnMultipleValues;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void GivenAGetValuesUsingTuple_WhenCallthisMethod_ThenReturnMultipleValues()
        {
            var (stringValue, boolValue, intValue) = MultipleValuesReturner.GetValuesUsingTuple();

            Assert.Equal("Some String Value", stringValue);
            Assert.False(boolValue);
            Assert.Equal(int.MaxValue, intValue);
        }

        [Fact]
        public void GivenAGetValuesUsingTupleLiterals_WhenCallThisMethod_ThenReturnMultipleValues()
        {
            var (stringValue, boolValue, intValue) = MultipleValuesReturner.GetValuesUsingTupleLiterals();

            Assert.Equal("Some String Value", stringValue);
            Assert.False(boolValue);
            Assert.Equal(int.MaxValue, intValue);
        }

        [Fact]
        public void GivenAGetValuesUsingOutKeyword_WhenCallThisMethod_ThenReturnMultipleValues()
        {
            string stringValue;
            bool boolValue;
            int intValue;

            MultipleValuesReturner.GetValuesUsingOutKeyword(out stringValue, out boolValue, out intValue);

            Assert.Equal("Some String Value", stringValue);
            Assert.False(boolValue);
            Assert.Equal(int.MaxValue, intValue);
        }

        [Fact]
        public void GivenAGetValuesUsingArrayOfObject_WhenCallThisMethod_ThenReturnMultipleValues()
        {
            var result = MultipleValuesReturner.GetValuesUsingArrayOfObject();

            Assert.Equal("Some String Value", result[0]);
            Assert.False((bool)result[1]);
            Assert.Equal(int.MaxValue, result[2]);
        }

        [Fact]
        public void GivenAGetValuesUsingDictionary_WhenCallThisMethod_ThenReturnMultipleValues()
        {
            var result = MultipleValuesReturner.GetValuesUsingDictionary();

            Assert.Equal("Some String Value", result["stringValue"]);
            Assert.False((bool)result["boolValue"]);
            Assert.Equal(int.MaxValue, result["intValue"]);
        }

        [Fact]
        public void GivenAGetValuesUsingObjectInstance_WhenCallThisMethod_ThenReturnMultipleValues()
        {
            var result = MultipleValuesReturner.GetValuesUsingObjectInstance();

            Assert.Equal("Some String Value", result.StringValue);
            Assert.False(result.BoolValue);
            Assert.Equal(int.MaxValue, result.IntValue);
        }
    }
}