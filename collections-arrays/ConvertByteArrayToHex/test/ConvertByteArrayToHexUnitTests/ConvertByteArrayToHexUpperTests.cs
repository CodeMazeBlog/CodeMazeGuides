namespace ConvertByteArrayToHexUnitTests;

public class ConvertByteArrayToHexUpperTests
{
    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B9-8E-24-4C", new byte[] {185, 142, 36, 76})]
    [InlineData("6A-2E-4F-58-9E-21-04-DE-DF-73-77-B8-B1-FB-27-BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData(
        "47-E9-A4-E0-53-B0-21-22-42-51-03-45-FC-2A-66-0E-A8-70-77-BD-E0-03-1A-0F-B0-42-D4-01-15-40-B9-03-FA-25-5A-ED-5C-5C-CA-12-3F-3F-0F-B9-FF-9E-4E-11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingBitConverter_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected, byte[] source)
    {
        var result = ConversionHelpers.ToHexWithBitConverter(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingBitConverter_WhenConvertingAByteArrayAndRemovingDashes_ThenGetCorrectHexString(string expected,
        byte[] source)
    {
        var result = ConversionHelpers.ToHexWithBitConverter(source, true);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingStringBuilderAppend_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected,
        byte[] source)
    {
        var result = ConversionHelpers.ToHexWithStringBuilderAppend(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingTryFormatAndCreate_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected,
        byte[] source)
    {
        var result = ConversionHelpers.ToHexWithTryFormatAndStringCreate(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingBitManipulation_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected, byte[] source)
    {
        var result = ConversionHelpers.ToHexWithBitManipulation(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingAlphabetSpanLookup_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected, byte[] source)
    {
        var result = ConversionHelpers.ToHexWithAlphabetSpanLookup(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingLookup_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected, byte[] source)
    {
        var result = ConversionHelpers.ToHexWithLookup(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingLookupNetStandard20_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected,
        byte[] source)
    {
        var result = ConversionHelpers.ToHexWithLookupNetStandard20(source);

        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("", new byte[] { })]
    [InlineData("B98E244C", new byte[] {185, 142, 36, 76})]
    [InlineData("6A2E4F589E2104DEDF7377B8B1FB27BD",
        new byte[] {106, 46, 79, 88, 158, 33, 4, 222, 223, 115, 119, 184, 177, 251, 39, 189})]
    [InlineData("47E9A4E053B0212242510345FC2A660EA87077BDE0031A0FB042D4011540B903FA255AED5C5CCA123F3F0FB9FF9E4E11",
        new byte[]
        {
            71, 233, 164, 224, 83, 176, 33, 34, 66, 81, 3, 69, 252, 42, 102, 14, 168, 112, 119,
            189, 224, 3, 26, 15, 176, 66, 212, 1, 21, 64, 185, 3, 250, 37, 90, 237, 92, 92, 202,
            18, 63, 63, 15, 185, 255, 158, 78, 17
        })]
    public void UsingConvert_WhenConvertingAByteArray_ThenGetCorrectHexString(string expected, byte[] source)
    {
        var result = ConversionHelpers.ToHexWithConvert(source);

        Assert.Equal(expected, result);
    }
}