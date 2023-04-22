namespace StringReverse
{
    public partial class Methods
    {
        public static string? StringExtensionReverseMethod(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}