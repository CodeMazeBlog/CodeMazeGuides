namespace StandardAndCustomFormatStringsTests;

public class StandardFormatStringsTests
{
  [Theory]
  [InlineData(1234.56, "1,234.56")]
  public void GivenANumber_WhenCurrencyFormat_ReturnsCurrency(double input, string expected)
  {
    string result = StandardFormatStrings.CurrencyFormat(input);

    Assert.Contains(expected, result);
  }

  [Theory]
  [InlineData(1234.56, "1 234,56 €")]
  public void GivenANumber_WhenEuroCurrency_ReturnsCurrencyInEuro(double input, string expected)
  {
    string result = StandardFormatStrings.EuroCurrency(input);

    Assert.Contains(expected, result);
  }

  [Theory]
  [InlineData(1234, "1234")]
  public void GivenANumber_WhenDecimalFormat_ReturnsDecimalNumber(int input, string expected)
  {
    string result = StandardFormatStrings.DecimalFormat(input);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(1234.5678, "1234.57")]
  public void GivenANumber_WhenFixedPointFormat_ReturnsRoundedNumber(double input, string expected)
  {
    string result = StandardFormatStrings.FixedPointFormat(input);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(123, "00123")]
  public void GivenANumber_WhenDecimalPrecision_ReturnsFiveDigitNumber(int input, string expected)
  {
    string result = StandardFormatStrings.DecimalPrecision(input);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(1234.5678, "1234.57")]
  public void GivenANumber_WhenFloatingPointPrecision_ReturnsRoundedFloatingNumber(double input, string expected)
  {
    string result = StandardFormatStrings.FloatingPointPrecision(input);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(0.1234, "%")]
  public void GivenANumber_WhenPercentage_ReturnsPercentage(double input, string expected)
  {
    string result = StandardFormatStrings.Percentage(input);

    Assert.Contains(expected, result);
  }

  [Theory]
  [InlineData(1.005, "1.00")]
  [InlineData(0.125, "0.12")]
  public void GivenAnApparentMidpoint_WhenFloatingPointPrecision_ThenTheStoredBinaryValueDecides(double input, string expected)
  {
    string result = StandardFormatStrings.FloatingPointPrecision(input);

    Assert.Equal(expected, result);
  }

  [Fact]
  public void GivenAMidpoint_WhenFixedPointPrecisionDecimal_ThenItRoundsAwayFromZero()
  {
    Assert.Equal("1.01", StandardFormatStrings.FixedPointPrecisionDecimal(1.005m));
    Assert.Equal("0.13", StandardFormatStrings.FixedPointPrecisionDecimal(0.125m));
  }

  [Theory]
  [InlineData(1652.5899, "    1,652.59")]
  public void GivenAValue_WhenAligned_ThenItIsRightAlignedInATwelveCharacterField(double input, string expected)
  {
    string result = StandardFormatStrings.Aligned(input);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(1652.5899, "1,652.59    ")]
  public void GivenAValue_WhenAlignedInterpolated_ThenANegativeWidthLeftAlignsIt(double input, string expected)
  {
    string result = StandardFormatStrings.AlignedInterpolated(input);

    Assert.Equal(expected, result);
  }

  [Fact]
  public void GivenABigEnoughBuffer_WhenTryFormatFixedPoint_ThenItWritesTheValueAndReturnsTrue()
  {
    Span<char> buffer = stackalloc char[16];

    bool succeeded = StandardFormatStrings.TryFormatFixedPoint(1652.5899, buffer, out int charsWritten);

    Assert.True(succeeded);
    Assert.Equal(7, charsWritten);
    Assert.Equal("1652.59", buffer[..charsWritten].ToString());
  }

  [Fact]
  public void GivenATooSmallBuffer_WhenTryFormatFixedPoint_ThenItWritesNothingAndReturnsFalse()
  {
    Span<char> buffer = stackalloc char[2];

    bool succeeded = StandardFormatStrings.TryFormatFixedPoint(1652.5899, buffer, out int charsWritten);

    Assert.False(succeeded);
    Assert.Equal(0, charsWritten);
  }
}
