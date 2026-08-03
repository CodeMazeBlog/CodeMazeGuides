using GetValueByKeyFromJObject;

namespace Tests
{
    public class JObjectManipulationUnitTest
    {
        private readonly JObjectManipulation _jObjectManipulation;

        public JObjectManipulationUnitTest()
        {
            _jObjectManipulation = new JObjectManipulation();
        }

        [Theory]
        [InlineData(5)]
        public void WhenGetValuesUsingIndexMethodIsUsed_ThenReturnFiveValues(int expected)
        {
            var actualCount = _jObjectManipulation.GetValuesUsingIndex();

            Assert.Equal(expected, actualCount);
        }

        [Theory]
        [InlineData(5)]
        public void WhenGetValuesUsingValueMethodIsUsed_ThenReturnFiveValues(int expected)
        {
            var actualCount = _jObjectManipulation.GetValuesUsingValueMethod();

            Assert.Equal(expected, actualCount);
        }

        [Theory]
        [InlineData(5)]
        public void WhenGetValuesUsingSelectTokenIsUsed_ThenReturnFiveValues(int expected)
        {
            var actualCount = _jObjectManipulation.GetValuesUsingSelectToken();

            Assert.Equal(expected, actualCount);
        }
        
        [Theory]
        [InlineData(5)]
        public void WhenGetValuesUsingTryGetValueIsUsed_ThenReturnFiveValues(int expected)
        {
            var actualCount = _jObjectManipulation.GetValuesUsingTryGetValue(); 

            Assert.Equal(expected, actualCount);
        }
    }
}
