using System.Security.Cryptography;
using System.Text;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? FastGenMethod(int length)
        {
            var data = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(data);
            }

            var result = new StringBuilder(length);
            foreach (var b in data)
            {
                result.Append(chars[b % chars.Length]);
            }

            return result.ToString();
        }
    }
}
