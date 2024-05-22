using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace BouncyCastleCryptography.Hashing;

public static class ShaHasher
{
    public static byte[] ShaHash(string secret)
    {
        var hash = new Sha256Digest();

        var result = new byte[hash.GetDigestSize()];

        var data = Encoding.UTF8.GetBytes(secret);

        hash.BlockUpdate(data, 0, data.Length);

        hash.DoFinal(result, 0);

        return result;
    }
}