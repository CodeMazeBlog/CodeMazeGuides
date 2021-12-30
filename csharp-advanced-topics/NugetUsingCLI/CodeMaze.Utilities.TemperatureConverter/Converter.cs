namespace CodeMaze.Utilities.TemperatureConverter
{
    public static class Converter
    {
        public static double ToFahrenHeit(double degreeCelsiusTemp)
        {
            return (degreeCelsiusTemp * 9 / 5) + 32;
        }

        public static double ToDegreeCelsius(double fahrenHeitTemp)
        {
            return (fahrenHeitTemp - 32) * 5 / 9;
        }
    }
}