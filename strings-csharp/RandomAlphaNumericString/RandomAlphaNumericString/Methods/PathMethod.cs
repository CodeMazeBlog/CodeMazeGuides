using System;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? PathMethod(int length)
        {
            var path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path.Substring(0, Math.Min(length, 8));
        }
    }
}
