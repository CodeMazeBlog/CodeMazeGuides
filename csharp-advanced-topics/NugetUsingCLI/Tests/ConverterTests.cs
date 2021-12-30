using CodeMaze.Utilities.TemperatureConverter;
using Xunit;

namespace Tests
{
    public class ConverterTests
    {
        [Fact]
        public void WhenProvidedDegreeCelsiusValue_ReturnsFahrenHeitValue()
        {
            Assert.Equal(77, Converter.ToFahrenHeit(25));
        }

        [Fact]
        public void WhenProvidedFahrenHeitValue_ReturnsDegreeCelsiusValue()
        {
            Assert.Equal(25, Converter.ToDegreeCelsius(77));
        }
    }
}