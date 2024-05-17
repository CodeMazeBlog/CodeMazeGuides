using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Text;

namespace BouncyCastleCryptography.SymmetricEncryption;

public static class TripleDesEncryptor
{
    public static byte[] TripleDesEncrypt(string input, out byte[] ivBytes, out byte[] keyBytes)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);

        // Generate a random 192-bit key (Triple DES key size)
        keyBytes = new byte[24];
        var random = new SecureRandom();
        random.NextBytes(keyBytes);

        // Generate a random 64-bit IV (initialization vector)
        ivBytes = new byte[8];
        random.NextBytes(ivBytes);

        // Create Triple DES cipher with CBC mode
        var cipher = CipherUtilities.GetCipher("DESede/CBC/PKCS7Padding");

        cipher.Init(true, new ParametersWithIV(new DesEdeParameters(keyBytes), ivBytes));

        return cipher.DoFinal(inputBytes);
    }

    public static string TripleDesDecrypt(byte[] key, byte[] iv, byte[] encryptedBytes)
    {
        var cipher = CipherUtilities.GetCipher("DESede/CBC/PKCS7Padding");
        cipher.Init(false, new ParametersWithIV(new DesEdeParameters(key), iv));

        // Decrypt the encrypted data
        var decryptedBytes = cipher.DoFinal(encryptedBytes);

        return Encoding.UTF8.GetString(decryptedBytes);
    }
}