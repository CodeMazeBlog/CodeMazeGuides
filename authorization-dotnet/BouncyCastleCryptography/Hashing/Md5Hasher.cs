using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyCastleCryptography.Hashing
{
    public static class Md5Hasher
    {
        public static byte[] Md5Hash(string secret)
        {
            IDigest hash = new MD5Digest();

            byte[] result = new byte[hash.GetDigestSize()];

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(secret)))
            {
                byte[] buffer = new byte[4092];
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
}
