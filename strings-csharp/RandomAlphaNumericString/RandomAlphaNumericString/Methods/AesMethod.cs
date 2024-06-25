using System.Security.Cryptography;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        //Maximal Length: 44
        public static string? AesMethod(int length)
        {
            using var crypto = Aes.Create();
            crypto.GenerateKey();
            return Convert.ToBase64String(crypto.Key).Substring(0, length);
        }
    }
}
