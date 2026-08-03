using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace BouncyCastleCryptography.Hashing;

public static class Md5Hasher
{
    public static byte[] Md5Hash(string secret)
    {
        var hash = new MD5Digest();

        var result = new byte[hash.GetDigestSize()];

        var data = Encoding.UTF8.GetBytes(secret);

        hash.BlockUpdate(data, 0, data.Length);

        hash.DoFinal(result, 0);

        return result;
    }
}