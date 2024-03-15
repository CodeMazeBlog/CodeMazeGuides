namespace StringFormattableString
{
    public class TemperatureFormat : IFormattable
    {
        private double _temperatureValue;

        public TemperatureFormat(double temperatureValue)
        {
            _temperatureValue = temperatureValue;
        }

        public string ToString(string format, IFormatProvider _) => format switch
        {
            "F" => $"{_temperatureValue * 9 / 5 + 32} F",
            "K" => $"{_temperatureValue + 273.15} K",
            _ => $"{_temperatureValue} C"
        };
    }
}