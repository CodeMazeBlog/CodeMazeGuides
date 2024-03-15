namespace StringReverse
{
    public partial class Methods
    {
        public static string? ReverseXorMethod(string stringToReverse)
        {
            var charArray = stringToReverse.ToCharArray();
            var len = stringToReverse.Length - 1;

            for (int i = 0; i < len; i++, len--)
            {
                charArray[i] ^= charArray[len];
                charArray[len] ^= charArray[i];
                charArray[i] ^= charArray[len];
            }

            return new string(charArray);
        }
    }
}