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
        public void WhenValidHexPassedToFromHexWithCharacterWiseTranslation_ThenConversionSuccessful()
        {
            var result = ConvertHex.FromHexWithCharacterWiseTranslation(HexString);

            Assert.Equal(_expectedResult, result);
        }

        [Fact]
        public void WhenInvalidFormatHexPassedToFromHexWithCharacterWiseTranslation_ThenConverionFail()
        {
            Assert.Throws<FormatException>(() => ConvertHex.FromHexWithCharacterWiseTranslation("Hello"));
        }

        [Fact]
        public void WhenEmptyHexPassedToFromHexWithCharacterWiseTranslation_ThenConverionFail()
        {
            Assert.Empty(ConvertHex.FromHexWithCharacterWiseTranslation(string.Empty));
        }

        [Fact]
        public void WhenValidHexPassedToFromHexWithPointers_ThenConversionSuccessful()
        {
            var result = ConvertHex.FromHexWithPointers(HexString);

            Assert.Equal(_expectedResult, result);
        }

        [Fact]
        public void WhenInvalidFormatHexPassedToFromHexWithPointers_ThenConverionFail()
        {
            Assert.Throws<ArgumentException>(() => ConvertHex.FromHexWithPointers("Hello"));
        }

        [Fact]
        public void WhenEmptyHexPassedToFromHexWithPointers_ThenConverionFail()
        {
            Assert.Empty(ConvertHex.FromHexWithPointers(string.Empty));
        }

        [Fact]
        public void WhenValidHexPassedToFromHexWithSwitchComputation_ThenConversionSuccessful()
        {
            var result = ConvertHex.FromHexWithSwitchComputation(HexString);

            Assert.Equal(_expectedResult, result);
        }

        [Fact]
        public void WhenInvalidFormatHexPassedToFromHexWithSwitchComputation_ThenConverionFail()
        {
            Assert.Throws<ArgumentException>(() => ConvertHex.FromHexWithSwitchComputation("Hello"));
        }

        [Fact]
        public void WhenEmptyHexPassedToFromHexWithSwitchComputation_ThenConverionFail()
        {
            Assert.Empty(ConvertHex.FromHexWithSwitchComputation(string.Empty));
        }

        [Fact]
        public void WhenValidHexPassedToFromHexWithBitFiddle_ThenConversionSuccessful()
        {
            var result = ConvertHex.FromHexWithBitFiddle(HexString);

            Assert.Equal(_expectedResult, result);
        }

        [Fact]
        public void WhenInvalidFormatHexPassedToFromHexWithBitFiddle_ThenConverionFail()
        {
            Assert.Throws<ArgumentException>(() => ConvertHex.FromHexWithBitFiddle("Hello"));
        }

        [Fact]
        public void WhenEmptyHexPassedToFromHexWithBitFiddle_ThenConverionFail()
        {
            Assert.Empty(ConvertHex.FromHexWithBitFiddle(string.Empty));
        }

        [Fact]
        public void WhenValidHexPassedToFromHexWithLookup_ThenConversionSuccessful()
        {
            var result = ConvertHex.FromHexWithLookup(HexString);

            Assert.Equal(_expectedResult, result);
        }

        [Fact]
        public void WhenInvalidFormatHexPassedToFromHexWithLookup_ThenConverionFail()
        {
            Assert.Throws<ArgumentException>(() => ConvertHex.FromHexWithLookup("Hello"));
        }

        [Fact]
        public void WhenEmptyHexPassedToFromHexWithLookup_ThenConverionFail()
        {
            Assert.Empty(ConvertHex.FromHexWithLookup(string.Empty));
        }
    }
}