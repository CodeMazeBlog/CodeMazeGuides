using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System.Text;

namespace BouncyCastleCryptography.AsymmetricEncryption;

public static class RsaEncryptor
{
    public static AsymmetricCipherKeyPair GenerateRsaKeyPair()
    {
        var rsaKeyPairGen = new RsaKeyPairGenerator();
        rsaKeyPairGen.Init(new KeyGenerationParameters(new SecureRandom(), 2048));

        return rsaKeyPairGen.GenerateKeyPair();
    }

    public static byte[] RsaEncrypt(string input, AsymmetricKeyParameter publicKey)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);

        var cipher = new Pkcs1Encoding(new RsaEngine());

        cipher.Init(true, publicKey);

        return cipher.ProcessBlock(inputBytes, 0, inputBytes.Length);
    }

    public static string RsaDecrypt(byte[] encryptedBytes, AsymmetricKeyParameter privateKey)
    {
        var cipher = new Pkcs1Encoding(new RsaEngine());

        // Initialize the cipher for decryption with the private key
        cipher.Init(false, privateKey);

        // Decrypt the encrypted data
        var decryptedBytes = cipher.ProcessBlock(encryptedBytes, 0, encryptedBytes.Length);

        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
