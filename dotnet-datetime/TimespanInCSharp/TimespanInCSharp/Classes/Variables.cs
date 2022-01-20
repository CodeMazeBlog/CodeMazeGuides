namespace TimespanInCSharp.Classes
{
    public static class Variables
    {
        public enum TimePart
        {
            Day,
            Hour,
            Minute,
            Second,
            MilliSecond,
            Ticks
        }

        public enum Operation
        {
            Add,
            Substract,
            Parse,
            ParseExact,
            TryParse,
            TryParseExact
        }
    }
}
