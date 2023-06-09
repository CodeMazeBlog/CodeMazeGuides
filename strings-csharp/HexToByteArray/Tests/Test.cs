using HexToByteArray;

namespace Tests
{
    public class Test
    {
        private readonly ConvertHex _convertHex;
        private const string HexString = "FF008000";
        public Test()
        {
            _convertHex = new ConvertHex();
        }

        [Fact]
        public void WhenValidHexPassed_ThenConverionSuccessful()
        {
            byte[] expectedResult = { 255, 0, 128, 0 };
            var result = _convertHex.FromHexString(HexString);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void WhenInvalidFormatHexPassed_ThenConverionFail()
        {
            var expectedResult = "FormatException";
            try
            {
                var result = _convertHex.FromHexString("Hello");
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedResult, ex.GetType().Name);
            }
        }

        [Fact]
        public void WhenNullatHexPassed_ThenConverionFail()
        {
            var expectedResult = "ArgumentNullException";
            try
            {
                var result = _convertHex.FromHexString("");
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedResult, ex.GetType().Name);
            }
        }

        [Fact]
        public void WhenValidHexPassedToAlternative_ThenConversionSuccessful()
        {
            byte[] expectedResult = { 255, 0, 128, 0 };
            var result = _convertHex.FromHexStringAlternative(HexString);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void WhenInvalidFormatHexPassedToAlternative_ThenConverionFail()
        {
            var expectedResult = "FormatException";
            try
            {
                var result = _convertHex.FromHexStringAlternative("Hello");
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedResult, ex.GetType().Name);
            }
        }

        [Fact]
        public void WhenNullatHexPassedToAlternative_ThenConverionFail()
        {
            var expectedResult = "ArgumentNullException";
            try
            {
                var result = _convertHex.FromHexStringAlternative("");
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedResult, ex.GetType().Name);
            }
        }
    }
}