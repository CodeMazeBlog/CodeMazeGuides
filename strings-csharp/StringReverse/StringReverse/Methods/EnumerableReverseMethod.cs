namespace StringReverse
{
    public partial class Methods
    {
        public static string? EnumerableReverseMethod(string stringToReverse)
        {
            return string.Concat(Enumerable.Reverse(stringToReverse));
        }
    }
}