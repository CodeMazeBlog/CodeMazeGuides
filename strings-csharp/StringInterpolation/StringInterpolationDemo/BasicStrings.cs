namespace StringInterpolationDemo
{
    public static class BasicStrings
    {
        private const string World = "world";
        public const string ConstantString = $"Hello {World}!";

        public static string SimpleString(string name, string item)
        {
            return $"Hey {name}, where you goin' with that {item} in your hand?";
        }

        public static string ThisManyBottlesOfBeerOnTheWall(int bottles)
        {
            return $"{bottles} bottles of beer on the wall, {bottles} bottles of beer.";
        }

        public static string DisplayTableCell(int data, bool alignRight)
        {
            if (alignRight)
            {
                return $"{data,9:N2}";
            }
            else
            {
                return $"{data,-9:N2}";
            }
        }

        public static string NewLinesInExpression(int place)
        {
            return $"You took {place}{place switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th",
            }} place.";
        }
    }
}