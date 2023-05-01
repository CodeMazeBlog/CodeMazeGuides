namespace StringReverse
{
    public partial class Methods
    {
        public static string? ArrayReverseString(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}