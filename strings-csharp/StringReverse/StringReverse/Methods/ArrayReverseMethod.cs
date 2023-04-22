namespace StringReverse
{
    public partial class Methods
    {
        public static string ArrayReverseString(string input)
        {
            var charArray = input.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}