namespace ConvertHexStringToByteArray.UnitTests;

public class ConvertHexByteArrayTests
{
    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("0xB98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void GivenModularArithmeticMethod_WhenConvertingStringToByteArray_ThenGetCorrectByteArray(string source,
        byte[] expected)
    {
        var result = ConversionHelpers.FromHexWithModularArithmetic(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("0xB98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void GivenLookupMethod_WhenConvertingStringToByteArray_ThenGetCorrectByteArray(string source, byte[] expected)
    {
        var result = ConversionHelpers.FromHexWithLookup(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("0xB98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void GivenConvertMethod_WhenConvertingStringToByteArray_ThenGetCorrectByteArray(string source, byte[] expected)
    {
        var result = ConversionHelpers.FromHexWithConvert(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("0xB98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void GivenSwitchComputationMethod_WhenConvertingStringToByteArray_ThenGetCorrectByteArray(string source,
        byte[] expected)
    {
        var result = ConversionHelpers.FromHexWithSwitchComputation(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("0xB98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void GivenBitFiddleMethod_WhenConvertingStringToByteArray_ThenGetCorrectByteArray(string source, byte[] expected)
    {
        var result = ConversionHelpers.FromHexWithBitFiddle(source);

        Assert.Equal(expected, result);
    }
}