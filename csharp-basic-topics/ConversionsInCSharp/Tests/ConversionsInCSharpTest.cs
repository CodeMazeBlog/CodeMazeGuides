using ConversionsInCSharp;
using System.Globalization;

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

    // CONVERSIONS TO BOOLEANS

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromIntToBool_ThenNonZeroIsConvertedToTrue()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToBoolean, -36);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "-36 (System.Int32) -> True (System.Boolean)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromIntToBool_ThenZeroIsConvertedToFalse()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToBoolean, 0);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "0 (System.Int32) -> False (System.Boolean)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromDoubleToBool_ThenNonZeroIsConvertedToTrue()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToBoolean, 7.32);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "7.32 (System.Double) -> True (System.Boolean)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromFloatToBool_ThenNonZeroIsConvertedToTrue()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToBoolean, -5.6f);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "-5.6 (System.Single) -> True (System.Boolean)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromDecimalToBool_ThenNonZeroIsConvertedToTrue()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToBoolean, 880.32m);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "880.32 (System.Decimal) -> True (System.Boolean)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromTrueStringToBool_ThenStringIsConvertedToTrue()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToBoolean, "True");
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "True (System.String) -> True (System.Boolean)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromFalseStringToBool_ThenStringIsConvertedToFalse()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToBoolean, "false");
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "false (System.String) -> False (System.Boolean)";

        Assert.Equal(expected, output);
    }

    // CONVERSIONS BETWEEN NUMERIC AND NON-NUMERIC TYPES

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromBoolToInt_ThenTrueIsConvertedToOne()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt32, true);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "True (System.Boolean) -> 1 (System.Int32)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromBoolToInt_ThenFalseIsConvertedToZero()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt32, false);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "False (System.Boolean) -> 0 (System.Int32)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromStringToInt_ThenConversionIsSuccessful()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt32, "58");
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "58 (System.String) -> 58 (System.Int32)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromStringToDouble_ThenConversionIsSuccessful()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToDouble, "2.18");
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "2.18 (System.String) -> 2.18 (System.Double)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromIntToChar_ThenConversionIsSuccessful()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToChar, 89);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "89 (System.Int32) -> Y (System.Char)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromCharToInt_ThenConversionIsSuccessful()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToInt32, 'b');
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "b (System.Char) -> 98 (System.Int32)";

        Assert.Equal(expected, output);
    }

    // CONVERSIONS WITH DATETIME

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromDateTimeToString_ThenConversionIsSuccessful()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToString, new DateTime(2021, 10, 13, 4, 18, 5));
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "10/13/2021 4:18:05 AM (System.DateTime) -> 10/13/2021 4:18:05 AM (System.String)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenMakeConversionMethod_WhenConvertingFromStringToDateTime_ThenConversionIsSuccessful()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Utilities.MakeConversion(Convert.ToDateTime, "5/1/1787 2:11:00 AM");
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "5/1/1787 2:11:00 AM (System.String) -> 5/1/1787 2:11:00 AM (System.DateTime)";

        Assert.Equal(expected, output);
    }

    // CONVERSIONS WITH IFORMATPROVIDER

    [Fact]
    public void GivenIFormatProvider_WhenConvertingToDateTimeWithSwedishCulture_ThenConversionIsSuccessful()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Console.WriteLine(Convert.ToDateTime("12/11/2014", new CultureInfo("sv-SE")));
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "12/11/2014 12:00:00 AM";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenIFormatProvider_WhenConvertingToDecimalWithFrenchCulture_ThenConversionIsSuccessful()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Console.WriteLine(Convert.ToDecimal("12,54", new CultureInfo("fr-FR")));
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "12.54";

        Assert.Equal(expected, output);
    }

    // CONVERSIONS FROM CUSTOM OBJECTS

    [Fact]
    public void GivenCustomNoteType_WhenConvertingToneEToBool_ThenTrueIsReturned()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Note note = new('E');
        Utilities.MakeConversion(Convert.ToBoolean, note);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "ConversionsInCSharp.Note (ConversionsInCSharp.Note) -> True (System.Boolean)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenCustomNoteType_WhenConvertingToneBToInt64_ThenLongNumber2IsReturned()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Note note = new('B');
        Utilities.MakeConversion(Convert.ToInt64, note);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "ConversionsInCSharp.Note (ConversionsInCSharp.Note) -> 2 (System.Int64)";

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenCustomNoteType_WhenConvertingToneFToChar_ThenCharFIsReturned()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Note note = new('F');
        Utilities.MakeConversion(Convert.ToChar, note);
        var output = stringWriter.ToString().Trim();

        // Assert 
        var expected = "ConversionsInCSharp.Note (ConversionsInCSharp.Note) -> F (System.Char)";

        Assert.Equal(expected, output);
    }
}