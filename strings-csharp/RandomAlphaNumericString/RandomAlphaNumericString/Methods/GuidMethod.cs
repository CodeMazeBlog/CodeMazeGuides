namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? GuidMethod(int length)
        {
            return Guid.NewGuid().ToString("N").Substring(0, length < 32 ? length : 32);
        }
    }
}
