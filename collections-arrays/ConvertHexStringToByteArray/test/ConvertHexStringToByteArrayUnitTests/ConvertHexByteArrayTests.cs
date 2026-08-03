namespace ConvertHexStringToByteArray.UnitTests;

public class ConvertHexByteArrayTests
{
    public static TheoryData<string, byte[]> StandardValidTestData =>
        new()
        {
            {"", Array.Empty<byte>()},
            {"B98E244C", new byte[] {185, 142, 36, 76}},
            {"0xB98E244C", new byte[] {185, 142, 36, 76}},
            {"b98e244c", new byte[] {185, 142, 36, 76}},
            {
                "6A2E4F589E2104DEDF7377B8B1FB27BD",
                new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189}
            },
            {
                "47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",

                new byte[]
                {
                    71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
                    189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
                    18, 63, 63, 15, 185, 255, 158, 78, 17
                }
            }
        };

    public static TheoryData<string> StandardInvalidTestData =>
        new()
        {
            "0xA",
            "A",
            "ABCDEF0",
            "0xABCDEFG",
            "0x123456789",
            "0x0123456789Z"
        };

    [Theory]
    [MemberData(nameof(StandardValidTestData))]
    public void GivenModularArithmeticMethod_WhenConvertingStringToByteArray_ThenGetCorrectByteArray(string source,
        byte[] expected)
    {
        var result = ConversionHelpers.FromHexWithModularArithmetic(source);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void
        GivenModularArithmeticMethod_WhenHexStringWithInvalidCharactersIsProvided_ThenDoesNotThrowArgumentException()
    {
        var exception = Record.Exception(() => ConversionHelpers.FromHexWithModularArithmetic("AABBCCDDEEFFZZ"));

        Assert.Null(exception);
    }

    [Theory]
    [InlineData("0xA")]
    [InlineData("A")]
    [InlineData("ABCDEF0")]
    public void GivenModularArithmeticMethod_WhenOddLengthHexDataIsProvided_ThenThrowsArgumentException(string source)
    {
        Assert.Throws<ArgumentException>(() => ConversionHelpers.FromHexWithModularArithmetic(source));
    }

    [Theory]
    [MemberData(nameof(StandardValidTestData))]
    public void GivenSwitchComputationMethod_WhenConvertingStringToByteArray_ThenGetCorrectByteArray(string source,
        byte[] expected)
    {
        var result = ConversionHelpers.FromHexWithSwitchComputation(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(StandardInvalidTestData))]
    public void GivenSwitchComputationMethod_WhenInvalidHexDataIsProvided_ThenThrowsArgumentException(string source)
    {
        Assert.Throws<ArgumentException>(() => ConversionHelpers.FromHexWithSwitchComputation(source));
    }

    [Theory]
    [MemberData(nameof(StandardValidTestData))]
    public void GivenBitManipulationMethod_WhenConvertingStringToByteArray_ThenGetCorrectByteArray(string source,
        byte[] expected)
    {
        var result = ConversionHelpers.FromHexWithBitManipulation(source);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void
        GivenBitManipulationMethod_WhenHexStringWithInvalidCharactersIsProvided_ThenDoesNotThrowArgumentException()
    {
        var exception = Record.Exception(() => ConversionHelpers.FromHexWithBitManipulation("AABBCCDDEEFFZZ"));

        Assert.Null(exception);
    }

    [Theory]
    [InlineData("0xA")]
    [InlineData("A")]
    [InlineData("ABCDEF0")]
    public void GivenBitManipulationMethod_WhenOddLengthHexDataIsProvided_ThenThrowsArgumentException(string source)
    {
        Assert.Throws<ArgumentException>(() => ConversionHelpers.FromHexWithBitManipulation(source));
    }

    [Theory]
    [MemberData(nameof(StandardValidTestData))]
    public void GivenConvertMethod_WhenConvertingStringToByteArray_ThenGetCorrectByteArray(string source,
        byte[] expected)
    {
        var result = ConversionHelpers.FromHexWithConvert(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(StandardInvalidTestData))]
    public void GivenConvertMethod_WhenInvalidHexDataIsProvided_ThenThrowsFormatException(string source)
    {
        Assert.Throws<FormatException>(() => ConversionHelpers.FromHexWithConvert(source));
    }

    [Theory]
    [MemberData(nameof(StandardValidTestData))]
    public void GivenLookupMethod_WhenConvertingStringToByteArray_ThenGetCorrectByteArray(string source,
        byte[] expected)
    {
        var result = ConversionHelpers.FromHexWithLookup(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(StandardInvalidTestData))]
    public void GivenLookupMethod_WhenInvalidHexDataIsProvided_ThenThrowsArgumentException(string source)
    {
        Assert.Throws<ArgumentException>(() => ConversionHelpers.FromHexWithLookup(source));
    }
}