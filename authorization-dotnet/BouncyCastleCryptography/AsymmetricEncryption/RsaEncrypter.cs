using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyCastleCryptography.AsymmetricEncryption
{
    public static class RsaEncrypter
    {
        public static AsymmetricCipherKeyPair GenerateRsaKeyPair()
        {
            // Generate RSA key pair with 2048-bit key size
            RsaKeyPairGenerator rsaKeyPairGen = new RsaKeyPairGenerator();
            rsaKeyPairGen.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
            return rsaKeyPairGen.GenerateKeyPair();
        }

        public static byte[] RsaEncrypt(string input, AsymmetricKeyParameter publicKey)
        {
            // Convert the input string to bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Create RSA cipher with PKCS1 v1.5 padding
            IAsymmetricBlockCipher cipher = new Pkcs1Encoding(new RsaEngine());

            // Initialize the cipher for encryption with the public key
            cipher.Init(true, publicKey);

            // Encrypt the input data
            return cipher.ProcessBlock(inputBytes, 0, inputBytes.Length);
        }

        public static string RsaDecrypt(byte[] encryptedBytes, AsymmetricKeyParameter privateKey)
        {
            // Create RSA cipher with PKCS1 v1.5 padding
            IAsymmetricBlockCipher cipher = new Pkcs1Encoding(new RsaEngine());

            // Initialize the cipher for decryption with the private key
            cipher.Init(false, privateKey);

            // Decrypt the encrypted data
            byte[] decryptedBytes = cipher.ProcessBlock(encryptedBytes, 0, encryptedBytes.Length);

            // Convert the decrypted bytes back to a string
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
