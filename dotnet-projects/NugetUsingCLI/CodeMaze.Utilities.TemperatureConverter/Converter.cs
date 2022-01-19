namespace CodeMaze.Utilities.TemperatureConverter
{
    public static class Converter
    {
        public static double ToFahrenheit(double degreeCelsiusTemp)
        {
            return (degreeCelsiusTemp * 9 / 5) + 32;
        }

        public static double ToDegreeCelsius(double fahrenheitTemp)
        {
            return (fahrenheitTemp - 32) * 5 / 9;
        }
    }
}