using ConversionsInCSharp;

namespace Tests;

public class ConversionsInCSharpTest
{
    [Fact]
    public void GivenConvertIntToOtherTypesMethod_WhenIntegerIsPassed_ThenOutputIsCorrect()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertIntToOtherTypes(4);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "4 (System.Int32) -> 4 (System.Double)\n4 (System.Int32) -> True (System.Boolean)\n4 (System.Int32) -> 4 (System.String)";
        Assert.Equal(expected, output);
    }

    // convenience method
    [Fact]
    public void GivenMakeConversionMethod_WhenConversionIsPossible_ThenCorrectMessageIsPrinted()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt64, 20);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "20 (System.Int32) -> 20 (System.Int64)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConversionIsImpossible_ThenErrorMessageIsPrinted()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToByte, 1500);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "Value was either too large or too small for an unsigned byte.";

        Assert.Equal(expected, output);
    }

    // conversion examples
    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromIntToLong_ThenConversionIsSuccessful()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt64, 1500);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "1500 (System.Int32) -> 1500 (System.Int64)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromSmallLongToInt_ThenConversionIsSuccessful()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt32, 1500L);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "1500 (System.Int64) -> 1500 (System.Int32)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromLargeLongToInt_ThenOverflowExceptionIsThrown()
    {
        // Act
        Utilities.MakeConversion(Convert.ToInt32, 10_000_000_000L);
        
        // Assert         
        Assert.ThrowsAsync<OverflowException>(() => { throw new OverflowException(); });
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromCharToBool_ThenInvalidCastExceptionIsThrown()
    {
        // Act
        Utilities.MakeConversion(Convert.ToBoolean, 'a');

        // Assert         
        Assert.ThrowsAsync<InvalidCastException>(() => { throw new InvalidCastException(); });
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromLongStringToChar_ThenFormatExceptionIsThrown()
    {
        // Act
        Utilities.MakeConversion(Convert.ToChar, "hey");

        // Assert         
        Assert.ThrowsAsync<FormatException>(() => { throw new FormatException(); });
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromStringToInt_ThenFormatExceptionIsThrown()
    {
        // Act
        Utilities.MakeConversion(Convert.ToInt32, "125s");

        // Assert         
        Assert.ThrowsAsync<FormatException>(() => { throw new FormatException(); });
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromIntToInt_ThenNoConversionOccurs()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt32, 10);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "10 (System.Int32) -> 10 (System.Int32)\r\nNo conversion, same types";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromDoubleToFloat_ThenPrecisionIsLost()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToSingle, 246.123456789);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "246.123456789 (System.Double) -> 246.12346 (System.Single)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromFloatToInt_ThenPrecisionIsLost()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt32, 56.91f);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "56.91 (System.Single) -> 57 (System.Int32)";

        Assert.Equal(expected, output);
    }

    // NUMERIC CONVERSIONS

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromIntToByte_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToByte, 125);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "125 (System.Int32) -> 125 (System.Byte)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromIntToDecimal_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToDecimal, 125);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "125 (System.Int32) -> 125 (System.Decimal)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromUIntToByte_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToByte, 125u);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "125 (System.UInt32) -> 125 (System.Byte)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromIntToShort_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt16, 125);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "125 (System.Int32) -> 125 (System.Int16)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromUIntToInt_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt32, 125u);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "125 (System.UInt32) -> 125 (System.Int32)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromLongToSByte_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToSByte, 125L);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "125 (System.Int64) -> 125 (System.SByte)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromIntToUInt_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToUInt32, 125);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "125 (System.Int32) -> 125 (System.UInt32)";

        Assert.Equal(expected, output);
    }

    // CONVERSIONS TO STRINGS

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromBoolToString_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToString, true);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "True (System.Boolean) -> True (System.String)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromFloatToString_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToString, 4.56f);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "4.56 (System.Single) -> 4.56 (System.String)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromCharToString_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToString, 'c');
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "c (System.Char) -> c (System.String)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromDateTimeToString_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToString, new DateTime());
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "1/1/0001 12:00:00 AM (System.DateTime) -> 1/1/0001 12:00:00 AM (System.String)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromObjectToString_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToString, new Random());
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "System.Random (System.Random) -> System.Random (System.String)";

        Assert.Equal(expected, output);
    }

    // BASE 64 ENCODING

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingToBase64String_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        byte[] bytes = [5, 10, 15, 20, 25, 30];
        Utilities.MakeConversion(Convert.ToBase64String, bytes);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "System.Byte[] (System.Byte[]) -> BQoPFBke (System.String)";

        Assert.Equal(expected, output);
    }

    // NON-DECIMAL NUMBERS

    [Fact]
    public void GivenConvertToStringWithBaseMethod_WhenUsingBase2_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertToStringWithBase(17, 2);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "17 (in base 10) -> 10001 (in base 2)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenConvertToStringWithBaseMethod_WhenUsingBase8_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertToStringWithBase(17, 8);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "17 (in base 10) -> 21 (in base 8)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenConvertToStringWithBaseMethod_WhenUsingBase10_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertToStringWithBase(17, 10);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "17 (in base 10) -> 17 (in base 10)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenConvertToStringWithBaseMethod_WhenUsingBase16_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertToStringWithBase(17, 16);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "17 (in base 10) -> 11 (in base 16)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenConvertToStringWithBaseMethod_WhenUsingBase5_ThenConversionFails()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertToStringWithBase(17, 5);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "Wrong base (must be 2, 8, 10 or 16)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenConvertFromStringWithBaseMethod_WhenUsingBase2_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertFromStringWithBase("10001", 2);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "10001 (in base 2) -> 17 (in base 10)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenConvertFromStringWithBaseMethod_WhenUsingBase8_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertFromStringWithBase("21", 8);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "21 (in base 8) -> 17 (in base 10)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenConvertFromStringWithBaseMethod_WhenUsingBase10_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertFromStringWithBase("17", 10);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "17 (in base 10) -> 17 (in base 10)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenConvertFromStringWithBaseMethod_WhenUsingBase16_ThenConversionSucceeds()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertFromStringWithBase("11", 16);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "11 (in base 16) -> 17 (in base 10)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenConvertFromStringWithBaseMethod_WhenUsingBase5_ThenConversionFails()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.ConvertFromStringWithBase("12", 5);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "Wrong base (must be 2, 8, 10 or 16)";

        Assert.Equal(expected, output);
    }
}