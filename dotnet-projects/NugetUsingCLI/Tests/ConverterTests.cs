using CodeMaze.Utilities.TemperatureConverter;
using Xunit;

namespace Tests
{
    public class ConverterTests
    {
        [Fact]
        public void WhenProvidedDegreeCelsiusValue_ReturnsFahrenheitValue()
        {
            Assert.Equal(77, Converter.ToFahrenheit(25));
        }

        [Fact]
        public void WhenProvidedFahrenheitValue_ReturnsDegreeCelsiusValue()
        {
            Assert.Equal(25, Converter.ToDegreeCelsius(77));
        }
    }
}