namespace StringFormattableString
{
    public class TemperatureFormat : IFormattable
    {
        private double temperatureValue;

        public TemperatureFormat() { }

        public TemperatureFormat(double temperatureValue)
        {
            this.temperatureValue = temperatureValue;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == "C")
                return $"{temperatureValue} C";
            else if (format == "F")
                return $"{temperatureValue * 9 / 5 + 32} F";
            else
                return $"{temperatureValue + 273.15} K";
        }
    }
}
