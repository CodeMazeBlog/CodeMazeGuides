using System.Security.Cryptography;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? RandomNumberGenGetStringMethod(int length)
        {
            return RandomNumberGenerator.GetString(choices: charSet, length: length);
        }
    }
}
