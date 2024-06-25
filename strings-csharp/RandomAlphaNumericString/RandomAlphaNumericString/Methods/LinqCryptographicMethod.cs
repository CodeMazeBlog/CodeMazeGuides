using System.Security.Cryptography;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        internal static readonly RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
        public static string? LinqCryptographicMethod(int length)
        {
            var data = new byte[length];
            randomNumberGenerator.GetBytes(data);

            return new string(data.Select(b => charSet[b % charSet.Length]).ToArray());
        }
    }
}
