namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        // Only up to 32 characters
        public static string? GuidMethod(int length)
        {
            return Guid.NewGuid().ToString("N").Substring(0, length < 32 ? length : 32);
        }
    }
}
