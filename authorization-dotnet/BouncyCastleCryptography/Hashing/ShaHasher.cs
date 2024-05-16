using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto;
using System.Text;

namespace BouncyCastleCryptography.Hashing;

public static class ShaHasher
{
    public static byte[] ShaHash(string secret)
    {
        var hash = new Sha256Digest();

        var result = new byte[hash.GetDigestSize()];

        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(secret)))
        {
            var buffer = new byte[4092];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                hash.BlockUpdate(buffer, 0, bytesRead);
            }

            hash.DoFinal(result, 0);
        }

        return result;
    }
}