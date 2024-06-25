using System.Security.Cryptography;
using System.Text;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string CryptographicUniqueMethod(int length)
        {
            var data = new byte[4 * length];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            var result = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }
    }
}
