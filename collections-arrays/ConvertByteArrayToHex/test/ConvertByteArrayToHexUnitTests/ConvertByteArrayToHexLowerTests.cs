namespace ConvertByteArrayToHexUnitTests;

public class ConvertByteArrayToHexLowerTests
{
    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6a2e4f589e2104dedf7377b8b1fb27bd",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47e9a4e053b0212242510345fc2a660ea87077bde0031a0fb042d4011540b903fa255aed5c5cca123f3f0fb9ff9e4e11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingStringBuilderAppendToLower_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected,
        byte[] source)
    {
        var result = ConversionHelpers.ToHexWithStringBuilderAppend(source, true);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6a2e4f589e2104dedf7377b8b1fb27bd",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47e9a4e053b0212242510345fc2a660ea87077bde0031a0fb042d4011540b903fa255aed5c5cca123f3f0fb9ff9e4e11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingTryFormatAndCreateToLower_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected,
        byte[] source)
    {
        var result = ConversionHelpers.ToHexWithTryFormatAndStringCreate(source, true);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6a2e4f589e2104dedf7377b8b1fb27bd",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47e9a4e053b0212242510345fc2a660ea87077bde0031a0fb042d4011540b903fa255aed5c5cca123f3f0fb9ff9e4e11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingBitManipulationToLower_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected,
        byte[] source)
    {
        var result = ConversionHelpers.ToHexWithBitManipulation(source, true);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6a2e4f589e2104dedf7377b8b1fb27bd",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47e9a4e053b0212242510345fc2a660ea87077bde0031a0fb042d4011540b903fa255aed5c5cca123f3f0fb9ff9e4e11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingAlphabetSpanLookupToLower_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected,
        byte[] source)
    {
        var result = ConversionHelpers.ToHexWithAlphabetSpanLookup(source, true);

        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6a2e4f589e2104dedf7377b8b1fb27bd",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47e9a4e053b0212242510345fc2a660ea87077bde0031a0fb042d4011540b903fa255aed5c5cca123f3f0fb9ff9e4e11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingLookupToLower_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected, byte[] source)
    {
        var result = ConversionHelpers.ToHexWithLookup(source, true);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6a2e4f589e2104dedf7377b8b1fb27bd",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47e9a4e053b0212242510345fc2a660ea87077bde0031a0fb042d4011540b903fa255aed5c5cca123f3f0fb9ff9e4e11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingLookupNetStandard20ToLower_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected,
        byte[] source)
    {
        var result = ConversionHelpers.ToHexWithLookupNetStandard20(source, true);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("b98e244c", new byte[] {185, 142, 36, 76})]
    [InlineData("6a2e4f589e2104dedf7377b8b1fb27bd",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47e9a4e053b0212242510345fc2a660ea87077bde0031a0fb042d4011540b903fa255aed5c5cca123f3f0fb9ff9e4e11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingConvertToLower_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected, byte[] source)
    {
        var result = ConversionHelpers.ToHexWithConvert(source, true);

        Assert.Equal(expected, result);
    }
}