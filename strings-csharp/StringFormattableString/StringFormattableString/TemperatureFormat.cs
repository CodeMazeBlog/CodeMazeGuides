namespace StringFormattableString
{
    public class TemperatureFormat : IFormattable
    {
        private double _temperatureValue;

        public TemperatureFormat(double temperatureValue)
        {
            _temperatureValue = temperatureValue;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == "C")
                return $"{_temperatureValue} C";
            else if (format == "F")
                return $"{_temperatureValue * 9 / 5 + 32} F";
            else
                return $"{_temperatureValue + 273.15} K";
        }
    }
}