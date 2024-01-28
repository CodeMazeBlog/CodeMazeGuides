using ConvertHexadecimalToDecimal;

namespace ConvertHexaDecimalToDecimalTests;

[TestClass]
public class ConversionExamplesUnitTests
{
    private const string hexVal = "7FFFFFFF";
    private const int decimalVal = int.MaxValue;
    private readonly ConversionExamples _conversionExamples = new();
    
    [TestMethod]
    public void GivenADecimalValue_WhenDecimalToHexUsingToStringInvoked_VerifyAccurateConversion()
    {
        var result = _conversionExamples.DecimalToHexUsingToString(decimalVal);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(string));
        Assert.AreEqual(hexVal, result);
    }

    [TestMethod]
    public void GivenADecimalValue_WhenDecimalToHexUsingStringFormatInvoked_VerifyAccurateConversion()
    {
        var result = _conversionExamples.DecimalToHexUsingStringFormat(decimalVal);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(string));
        Assert.AreEqual(hexVal, result);
    }

    [TestMethod]
    public void GivenADecimalValue_WhenDecimalToHexUsingBitwiseMethodInvoked_VerifyAccurateConversion()
    {
        var result = _conversionExamples.DecimalToHexUsingBitwiseMethod(decimalVal);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(string));
        Assert.AreEqual(hexVal, result);
    }

    [TestMethod]
    public void GivenAHexadecimalValue_WhenHexToDecimalUsingParseInvoked_VerifyAccurateConversion()
    {
        var result = _conversionExamples.HexToDecimalUsingParse(hexVal);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(int));
        Assert.AreEqual(decimalVal, result);
    }

    [TestMethod]
    public void GivenAHexadecimalValue_WhenHexToDecimalUsingConvertInvoked_VerifyAccurateConversion()
    {
        var result = _conversionExamples.HexToDecimalUsingConvert(hexVal);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(int));
        Assert.AreEqual(decimalVal, result);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void GivenInvalidHexadecimalValue_WhenHexToDecimalUsingParseInvoked_VerifyAccurateConversion()
    {
        var invalidHex = "wxyz";

        var result = _conversionExamples.HexToDecimalUsingParse(invalidHex);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void GivenInvalidHexadecimalValue_WhenHexToDecimalUsingConvertInvoked_VerifyAccurateConversion()
    {
        var invalidHex = "wxyz";

        var result = _conversionExamples.HexToDecimalUsingConvert(invalidHex);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void GivenANullValue_WhenHexToDecimalUsingConvertInvoked_VerifyReturnsZero()
    {
        string? nullValue = null;

        var result = _conversionExamples.HexToDecimalUsingConvert(nullValue);

        Assert.IsNotNull(result);
        Assert.AreEqual(0, result);
    }
}