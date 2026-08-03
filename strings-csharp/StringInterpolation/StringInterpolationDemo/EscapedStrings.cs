namespace StringInterpolationDemo
{
    public static class EscapedStrings
    {
        public static string SimpleEscapedCurlyBraces()
        {
            const string item = "curly braces";

            return $"We show {{{item}}} inserted in the string.";
        }

        public static string ThisManyBottlesOfBeerOnTheWall(int bottles)
        {
            return $"{bottles} bottle{(bottles == 1 ? string.Empty : "s")} of beer on the wall.";
        }
    }
}