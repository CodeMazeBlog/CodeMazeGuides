using HexToByteArray;

namespace Tests
{
    public class Test
    {
        private const string HexString = "FF008000";
        private readonly byte[] _expectedResult = { 255, 0, 128, 0 };

        [Fact]
        public void WhenValidHexPassed_ThenConverionSuccessful()
        {
            var result = ConvertHex.FromHexString(HexString);

            Assert.Equal(_expectedResult, result);
        }

        [Fact]
        public void WhenInvalidFormatHexPassed_ThenConverionFail()
        {
            Assert.Throws<FormatException>(() => ConvertHex.FromHexString("Hello"));
        }

        [Fact]
        public void WhenEmptyHexPassedPassed_ThenConverionFail()
        {
            Assert.Empty(ConvertHex.FromHexString(string.Empty));
        }

        [Fact]
        public void WhenValidHexPassedToAlternative_ThenConversionSuccessful()
        {
            var result = ConvertHex.FromHexStringAlternative(HexString);

            Assert.Equal(_expectedResult, result);
        }

        [Fact]
        public void WhenInvalidFormatHexPassedToAlternative_ThenConverionFail()
        {
            Assert.Throws<FormatException>(() => ConvertHex.FromHexStringAlternative("Hello"));
        }

        [Fact]
        public void WhenEmptyHexPassedToAlternative_ThenConverionFail()
        {
            Assert.Empty(ConvertHex.FromHexStringAlternative(string.Empty));
        }
    }
}