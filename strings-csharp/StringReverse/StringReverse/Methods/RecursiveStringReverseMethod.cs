namespace StringReverse
{
    public partial class Methods
    {
        public static string? RecursiveStringReverseMethod(string s)
        {
            if (s.Length <= 1)
                return s;

            return s[^1] + RecursiveStringReverseMethod(s[1..^1]) + s[0];
        }
    }
}