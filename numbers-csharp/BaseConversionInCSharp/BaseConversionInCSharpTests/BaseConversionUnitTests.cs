using BaseConversionInCSharp;

namespace BaseConversionInCSharpTests;

[TestClass]
public class BaseConversionUnitTests
{
    const int decimalVal = 100;
    const string binaryVal = "1100100";
    const string octalVal = "144";
    const string hexVal = "64";
    const string base36Val = "2S";
    const string negativeBase36Val = "-2S";

    private readonly ConversionExamples _examples = new();

    [TestMethod]
    public void GivenADecimalValue_WhenConvertToStringInvoked_ThenVerifyAccurateResults()
    {
        var binaryResult = _examples.ConvertAnyBaseUsingToString(decimalVal, 2);
        var octalResult = _examples.ConvertAnyBaseUsingToString(decimalVal, 8);
        var hexResult = _examples.ConvertAnyBaseUsingToString(decimalVal, 16);

        Assert.AreEqual(binaryResult, binaryVal);
        Assert.AreEqual(octalResult, octalVal);
        Assert.AreEqual(hexResult, hexVal);
    }

    [TestMethod]
    public void GivenADecimalValue_WhenCustomMethodInvoked_ThenVerifyAccurateResults()
    {
        var base36Result = _examples.DecimalToAnyBase(decimalVal, 36);
        var binaryResult = _examples.DecimalToAnyBase(int.MaxValue, 2);

        Assert.IsNotNull(base36Result);
        Assert.IsNotNull(binaryResult);
        Assert.IsInstanceOfType(base36Result, typeof(string));
        Assert.IsInstanceOfType(binaryResult, typeof(string));
        Assert.AreEqual(base36Result, base36Val);
        Assert.AreEqual(binaryResult, Convert.ToString(int.MaxValue, 2));
    }

    [TestMethod]
    public void GivenAnyBaseValue_WhenConvertToInt32Invoked_ThenVerifyAccurateResults()
    {
        var binaryResult = _examples.AnyBaseToDecimalUsingConvert(binaryVal, 2);
        var octalResult = _examples.AnyBaseToDecimalUsingConvert(octalVal, 8);
        var hexResult = _examples.AnyBaseToDecimalUsingConvert(hexVal, 16);

        Assert.AreEqual(binaryResult, decimalVal);
        Assert.AreEqual(octalResult, decimalVal);
        Assert.AreEqual(hexResult, decimalVal);
    }

    [TestMethod]
    public void GivenAnyBaseValue_WhenConvertToDecimalWithCustomMethod_ThenVerifyAccurateResults()
    {
        var binaryResult = _examples.AnyBaseToDecimal(binaryVal, 2);
        var octalResult = _examples.AnyBaseToDecimal(octalVal, 8);
        var hexResult = _examples.AnyBaseToDecimal(hexVal, 16);
        var base36Result = _examples.AnyBaseToDecimal(base36Val, 36);
        var negativeBase36Result = _examples.AnyBaseToDecimal(negativeBase36Val, 36);

        Assert.AreEqual(binaryResult, decimalVal);
        Assert.AreEqual(octalResult, decimalVal);
        Assert.AreEqual(hexResult, decimalVal);
        Assert.AreEqual(base36Result, decimalVal);
        Assert.AreEqual(negativeBase36Result, -decimalVal);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException),
        "Enter radix between 2 and 36")]
    public void GivenOutOfRangeRadix_WhenCustomMethodInvoked_ThenVerifyArgumentException()
    {
        var result = _examples.DecimalToAnyBase(decimalVal, 1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException),
        "Enter 2, 8, 10, or 16 as the radix")]
    public void GivenOutOfRangeRadix_WhenConvertToStringInvoked_ThenVerifyArgumentException()
    {
        var result = _examples.ConvertAnyBaseUsingToString(decimalVal, 36);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException),
        "Enter 2, 8, 10, or 16 as the radix")]
    public void GivenOutOfRangeRadix_WhenConvertToIntInvoked_ThenVerifyArgumentException()
    {
        var result = _examples.AnyBaseToDecimalUsingConvert(binaryVal, 36);
    }
}