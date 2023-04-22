namespace StringReverse
{
    public partial class Methods
    {
        public static string? EnumerableReverseMethod(string s)
        {
            return string.Concat(Enumerable.Reverse(s));
        }
    }
}