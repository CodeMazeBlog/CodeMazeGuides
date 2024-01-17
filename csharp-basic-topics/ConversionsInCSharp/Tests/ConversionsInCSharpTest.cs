using ConversionsInCSharp;
using System.Globalization;

namespace Tests;

public class ConversionsInCSharpTest
{   
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

    // CONVERSIONS BETWEEN NUMERIC AND NON-NUMERIC TYPES

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
        var expected1 = "(System.DateTime)";
        var expected2 = "(System.String)";

        Assert.Contains(expected1, output); 
        Assert.Contains(expected2, output);
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
}