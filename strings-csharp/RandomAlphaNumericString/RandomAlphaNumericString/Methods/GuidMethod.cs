namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? GuidMethod(int length)
        {
            var str = "";

            do
            {
                str += Guid.NewGuid().ToString().Replace("-", "");
            }

            while (length > str.Length);

            return str.Substring(0, length);
        }
    }
}
