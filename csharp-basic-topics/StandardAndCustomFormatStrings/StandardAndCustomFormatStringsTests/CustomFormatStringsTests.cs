using System.Runtime.InteropServices;
using StandardAndCustomFormatStrings;

namespace StandardAndCustomNumericFormatStringsTests;

public class CustomFormatStringsTests
{

  [Theory]
  [InlineData(123.45, "00123")]
  public void GivenANumber_WhenDecimal_ReturnsDecimalNumber(double input, string expected)
  {
    string result = CustomFormatStrings.Decimal(input);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(123.45, "0123.45")]
  public void GivenANumber_WhenFloatingPoint_ReturnsFormattedFloatingNumber(double input, string expected)
  {
    string result = CustomFormatStrings.FloatingPoint(input);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(0.12345, "12.35%")]
  public void GIvenANumber_WhenPercentage_ReturnsPercentage(double input, string expected)
  {
    string result = CustomFormatStrings.Percentage(input);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(1234567.89, "1,234,567.89")]
  public void GivenANumber_WhenDigitSeparator_ReturnsSeparatedNumber(double input, string expected)
  {
    string result = CustomFormatStrings.DigitSeparator(input);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(1234567890, "(123) 456-7890")]
  public void GivenANumber_WhenPhone_ReturnsPhoneNumber(long input, string expected)
  {
    string result = CustomFormatStrings.Phone(input);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(1234567890, "(123) 456-7890")]
  public void GivenANumber_WhenPhoneInterpolated_ReturnsFormattedPhoneNumber(long input, string expected)
  {
    string result = CustomFormatStrings.PhoneInterpolated(input);

    Assert.Equal(expected, result);
  }
}