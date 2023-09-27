namespace StringReverse
{
    public partial class Methods
    {
        public static string? StringExtensionReverseMethod(string stringToReverse)
        {
            return new string(stringToReverse.Reverse().ToArray());
        }
    }
}