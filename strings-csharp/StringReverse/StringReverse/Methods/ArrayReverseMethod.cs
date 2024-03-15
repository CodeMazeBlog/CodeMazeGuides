namespace StringReverse
{
    public partial class Methods
    {
        public static string? ArrayReverseString(string stringToReverse)
        {
            var charArray = stringToReverse.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}