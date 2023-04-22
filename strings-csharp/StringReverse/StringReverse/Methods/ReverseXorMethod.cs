namespace StringReverse
{
    public partial class Methods
    {
        public static string? ReverseXorMethod(string s)
        {
            if (s == null) 
                return s;

            var charArray = s.ToCharArray();
            var len = s.Length - 1;

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